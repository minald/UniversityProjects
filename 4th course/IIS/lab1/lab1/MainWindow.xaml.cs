using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace lab1
{
    public partial class MainWindow : Window
    {
        public static readonly string CurrentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public readonly string KnowledgeBasePath = Path.Combine(CurrentDirectory, "Knowledge base.txt");
        public static Logger Logger = LogManager.GetCurrentClassLogger();

        public List<Rule> Rules { get; set; } = new List<Rule>();
        public Stack<string> Targets { get; set; } = new Stack<string>();
        public string MainTarget { get; set; }
        public List<Property> Context { get; set; } = new List<Property>();
        public Property CurrentAnswer { get; set; } = new Property();
        public bool Flag { get; set; } = false;

        public MainWindow()
        {
            InitializeComponent();
            FillKnowledgeBase();
            MainTarget = Rules.First().Target.Key;
            Logger.Info("Главная цель: " + MainTarget);
            Targets.Push(MainTarget);
            CurrentAnswer.Key = Rules.First().Properties.First().Key;
            Targets.Push(CurrentAnswer.Key);
            Logger.Info(CurrentAnswer.Key + " помещена в стек целей");
            PropertyKeyLabel.Content = Char.ToUpper(CurrentAnswer.Key[0]) + CurrentAnswer.Key.Substring(1) + ":";
        }

        private void ChooseTarget_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TargetTextBox.Text))
            {
                MainTarget = TargetTextBox.Text;
            }
            Targets.Clear();
            Targets.Push(MainTarget);
            Logger.Info("Главная цель: " + MainTarget);
            CurrentAnswer.Key = Rules.FirstOrDefault(x => x.Target.Key == MainTarget).Properties.First().Key;
            Targets.Push(CurrentAnswer.Key);
            Logger.Info(CurrentAnswer.Key + " помещена в стек целей");
            PropertyKeyLabel.Content = Char.ToUpper(CurrentAnswer.Key[0]) + CurrentAnswer.Key.Substring(1) + ":";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            CurrentAnswer.Value = InputTextBox.Text;
            if (String.IsNullOrEmpty(CurrentAnswer.Value))
            {
                Rule newRule = GetNextRule(Targets.Peek());
                WorkWithNewRule(newRule);
            }
            else
            {
                Context.Add(new Property(CurrentAnswer.Key, CurrentAnswer.Value));
                Logger.Info(CurrentAnswer.Key + " - " + CurrentAnswer.Value + " : помещены в контекстный стек");
                Targets.Pop();
                Rule currentRule = GetNextRule(Targets.Peek());
                if(currentRule == null)
                {
                    Flag = true;
                }
                else if (GetNextVerifiableProperty(currentRule) != null)
                {
                    Targets.Push(GetNextVerifiableProperty(currentRule).Key);
                    Logger.Info(GetNextVerifiableProperty(currentRule).Key + " : помещена в стек целей");
                    CurrentAnswer.Key = GetNextVerifiableProperty(currentRule).Key;
                    PropertyKeyLabel.Content = Char.ToUpper(CurrentAnswer.Key[0]) + CurrentAnswer.Key.Substring(1) + ":";
                    InputTextBox.Clear();
                }
                else
                {
                    Context.Add(new Property(currentRule.Target.Key, currentRule.Target.Value));
                    Logger.Info(currentRule.Target.Key + " - " + currentRule.Target.Value + " : сделан вывод");
                    Targets.Pop();
                    if (Targets.Any())
                    {
                        Rule newRule = GetNextRule(Targets.Peek());
                        WorkWithNewRule(newRule);
                    }
                    else
                    {
                        Flag = true;
                    }
                }
            }

            if (Flag)
            {
                if (Context.Select(x => x.Key).Contains(MainTarget))
                {
                    AnswerLabel.Content = MainTarget + " - " + Context.First(x => x.Key == MainTarget).Value;
                }
                else
                {
                    AnswerLabel.Content = "Ответа нет.";
                }
            }
        }

        private void FillKnowledgeBase()
        {
            Logger.Info("Начало разбора базы знаний");
            string knowledgeBase = File.ReadAllText(KnowledgeBasePath, Encoding.UTF8).ToLower();
            string[] rules = knowledgeBase.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string ruleString in rules)
            {
                string[] rows = ruleString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                Rule rule = new Rule();
                foreach (string row in rows)
                {
                    if (row.StartsWith("то"))
                    {
                        string target = row.Substring(2).Trim();
                        string[] keyAndValue = target.Split('-');
                        rule.Target = new Property(keyAndValue[0].Trim(), keyAndValue[1].Trim());
                        Logger.Info("Цель: " + keyAndValue[0].Trim() + " " + keyAndValue[1].Trim());
                    }
                    else
                    {
                        string property = row.StartsWith("если") ? row.Substring(4) : row;
                        property = property.EndsWith(" и") ? property.Substring(0, property.Length - 1).Trim() : property;
                        string[] keyAndValue = property.Split('-');
                        rule.Properties.Add(new Property(keyAndValue[0].Trim(), keyAndValue[1].Trim()));
                        Logger.Info("Свойство: " + keyAndValue[0].Trim() + " " + keyAndValue[1].Trim());
                    }
                }

                Rules.Add(rule);
            }
            Logger.Info("Конец разбора базы знаний");
        }

        private Property GetNextVerifiableProperty(Rule rule)
        {
            return rule.Properties.FirstOrDefault(x => !Context.Select(y => y.Key).Contains(x.Key));
        }

        private Rule GetNextRule(string currentTarget)
        {
            var possibleRules = Rules.Where(x => x.Target.Key == currentTarget && !x.IsWrong);
            foreach (var possibleRule in possibleRules)
            {
                foreach (var property in possibleRule.Properties)
                {
                    var contextPair = Context.FirstOrDefault(x => x.Key == property.Key);
                    if(contextPair == null)
                    {
                        return possibleRule;
                    }
                    else if (contextPair.Value != property.Value)
                    {
                        possibleRule.IsWrong = true;
                        break;
                    }
                }
                if (!possibleRule.IsWrong)
                {
                    return possibleRule;
                }
            }
            return null;
        }

        private void WorkWithNewRule(Rule newRule)
        {
            if (newRule == null)
            {
                Flag = true;
            }
            else
            {
                if (GetNextVerifiableProperty(newRule) == null)
                {
                    Context.Add(new Property(newRule.Target.Key, newRule.Target.Value));
                    Logger.Info(newRule.Target.Key + " - " + newRule.Target.Value + " : помещены в контекстный стек");
                    Flag = true;
                }
                else
                {
                    Targets.Push(GetNextVerifiableProperty(newRule).Key);
                    Logger.Info(GetNextVerifiableProperty(newRule).Key + " : помещена в стек целей");
                    CurrentAnswer.Key = GetNextVerifiableProperty(newRule).Key;
                    PropertyKeyLabel.Content = Char.ToUpper(CurrentAnswer.Key[0]) + CurrentAnswer.Key.Substring(1) + ":";
                    InputTextBox.Clear();
                }
            }
        }
    }

    public class Rule
    {
        public List<Property> Properties { get; set; } = new List<Property>();
        public Property Target { get; set; }
        public bool IsWrong { get; set; } = false;

        public Rule() { }

        public Rule(List<Property> properties, Property target)
        {
            Properties = properties;
            Target = target;
        }
    }

    public class Property
    {
        public string Key { get; set; }
        public string Value { get; set; } // Empty means unknown

        public Property() {}

        public Property(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
