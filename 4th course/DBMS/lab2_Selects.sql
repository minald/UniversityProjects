--1. Найти сведения обо всех партиях, сыгранных конкретным шахматистом (имя игрока – параметр запроса);
SELECT Games.Id, Games.GameDate, b.LastName, w.LastName, Games.Result, Games.Debute, Games.Moves 
FROM Games
    LEFT JOIN Players b ON Games.WhitePlayerId = b.Id
    LEFT JOIN Players w ON Games.BlackPlayerId = w.Id
WHERE b.LastName = 'Caruana' OR w.LastName = 'Caruana'

--2. Найти сведения обо всех шахматистах, не плативших членские взносы в течение текущего года;
SELECT * 
FROM Players
WHERE AnnualMemberPayment = 'false'

--3. Найти сведения о пяти самых старых шахматистах, игравших в турнирах текущего года. Включить в результат запроса сумму денег, выигранную ими на этих турнирах;
SELECT X.*, Y.Prizes
FROM(
    SELECT * FROM Players
    WHERE Id IN
        (SELECT DISTINCT PlayerId FROM TournamentPlayers
        WHERE TournamentId IN
            (SELECT Id FROM Tournaments 
            WHERE EXTRACT(YEAR from StartDate) = EXTRACT(YEAR FROM sysdate)))
    ORDER BY BirthDate) X
LEFT JOIN (SELECT PlayerId, SUM(Prize) AS Prizes FROM TournamentPlayers
        WHERE TournamentId IN
            (SELECT Id FROM Tournaments 
            WHERE EXTRACT(YEAR from StartDate) = EXTRACT(YEAR FROM sysdate))
        GROUP BY PlayerId) Y
        ON Y.PlayerId = X.Id
WHERE ROWNUM <= 5
