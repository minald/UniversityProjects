-- 1.Триггер должен не допускать к участию в турнире шахматиста, не оплатившего взнос.
CREATE OR REPLACE TRIGGER task1
AFTER INSERT OR UPDATE ON TournamentPlayers
FOR EACH ROW
DECLARE isPaid VARCHAR2(5);
BEGIN
  SELECT AnnualMemberPayment into isPaid FROM Players WHERE Id = :new.PlayerId;
  IF isPaid = 'false'
    THEN RAISE_APPLICATION_ERROR(-20001, 'Annual member payment has not been paid');
  END IF;
END;
INSERT INTO TournamentPlayers VALUES (25, 1, 10, 1000);
INSERT INTO TournamentPlayers VALUES (25, 1, 15, 1000);

-- 2.Триггер должен сообщить о превышении оплаты взноса, если шахматист имеет льготы.
CREATE OR REPLACE TRIGGER task2
AFTER INSERT OR UPDATE ON TournamentPlayers
FOR EACH ROW
DECLARE discount NUMBER;
BEGIN
  SELECT ClubMemberDiscount into discount FROM Players WHERE Id = :new.PlayerId;
  IF discount != 0
    THEN RAISE_APPLICATION_ERROR(-20002, 'The fee size is exceeded, the player has discount');
  END IF;
END;
INSERT INTO TournamentPlayers VALUES (26, 1, 5, 1000);
INSERT INTO TournamentPlayers VALUES (26, 1, 16, 1000);

-- 3.Триггер должен сообщить об ошибке, если количество ходов в партии меньше одного.
CREATE OR REPLACE TRIGGER task3
AFTER INSERT OR UPDATE ON Games
FOR EACH ROW
BEGIN
  IF :new.moves < 1
    THEN RAISE_APPLICATION_ERROR(-20003, 'The number of moves can not be zero');
  END IF;
END;
INSERT INTO Games VALUES (21, 1, TO_DATE('15-03-2018', 'dd-mm-yyyy'), 8, 3, '0.5-0.5', 'Queens Gambit', 0);
INSERT INTO Games VALUES (21, 1, TO_DATE('15-03-2018', 'dd-mm-yyyy'), 8, 3, '0.5-0.5', 'Queens Gambit', 1);
