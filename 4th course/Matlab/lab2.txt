clear; 
alphabet = 'abcdefghijklmnopqrstuvwxyz'; 
text = input('Enter text: ','s'); 
i = 1; 
n = input('Enter shift: '); 
result = text; 
while i <= length(text) 
	if isletter(text(i)) == 1 
		y = strfind(alphabet, text(i)); 
		z = y + n; 
		if z > 26 
			z = z - 26; 
		end 
		result(i) = alphabet(z); 
	end 
	i = i + 1; 
end 

frequencies = zeros(1, 27); 
for i=1:length(result) 
	for j=1:length(alphabet) 
		if result(i) == alphabet(j) 
			frequencies(j) = frequencies(j) + 1; 
		end 
	end 
end 

fprintf('Result = %s\n', result) 
frequencies
