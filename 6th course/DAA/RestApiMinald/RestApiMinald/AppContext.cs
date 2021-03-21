using Microsoft.EntityFrameworkCore;

namespace RestApiMinald
{
	public class AppContext : DbContext
    {
        public DbSet<ChessGame> ChessGames { get; set; }
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

/*
[
  {
    "id": 1,
    "whiteName": "Minald Andrey",
    "blackName": "Kovalevsky Stanislav",
    "result": "1-0",
    "tournamentName": "Lichess",
    "moves": "1. e4 e5 2. Cc4 h5 3. Ф:h5 Kf6 4. Ф:f7#"
  },
  {
    "id": 2,
    "whiteName": "Karpov Anatoliy",
    "blackName": "Kasparov Garry",
    "result": "0.5-0.5",
    "tournamentName": "World Chess Championship 1984",
    "moves": "1. e4 e5 2. ♘f3 ♞f6 3. ♘xe5 d6 4. ♘f3 ♞xe4 5. d4 d5 6. ♗d3 ♝e7 7. O‑O ♞c6 8. c4 ♞b4 9. ♗e2 dxc4 10. ♗xc4 O‑O 11. ♘c3 ♞d6 12. ♗b3 ♝f6 13. h3 ♝f5 14. ♗e3 ♜e8 15. a3 ♞d3 16. ♖b1 c5 17. dxc5 ♞e4 18. ♗c2 ♞xb2 19. ♕xd8 ♜axd8 20. ♖xb2 ♝xc3 21. ♖xb7 ♞xc5 22. ♗xc5 ♝xc2 23. ♖xa7 ♝d1 24. ♖e7 ♜xe7 25. ♗xe7 ♜d3 26. ♘g5 ♝b2 27. ♗b4 h6 28. ♘e4 f5 29. ♘c5 ♜d5 30. ♖e1 f4 31. a4 ♜d4 32. a5 ♜xb4 33. ♖xd1? ♝d4 34. ♘e6 ♝a7 35. ♖d7 ♜b1+ 36. ♔h2 ♝xf2 37. ♘xf4 ♜a1 38. ♘e6 ♜xa5 39. ♖xg7+ ♚h8 40. ♖f7 ♝e3 41. ♔g3 ♝d2 42. ♖d7 ♝c3 43. ♔f3 ♚g8 44. ♘f4 ♜f5 45. ♔e4 ♜f7 46. ♖d8+ ♚h7 47. ♖d3 ♜e7+ 48. ♔f3 ♝b2 49. ♖b3 ♝c1 50. ♘d5 ♜e5 51. ♘f6+ ♚g6 52. ♘e4 ♜f5+ 53. ♔e2 ♜e5 54. ♖b4 ♜e7 55. ♖c4 ♜e8 56. g3 ♝b2 57. ♔f3 ♜e6 58. ♖c5 ♝d4 59. ♖d5 ♝e5 60. ♖b5 ♝c7 61. ♖c5 ♝b6 62. ♖c8 ♝d4 63. ♖g8+ ♝g7 64. h4 ♜a6 65. ♔f4 ♜a5 66. ♖e8 ♜f5+ 67. ♔e3 ♜e5 68. ♖g8 ♜e7 69. ♔f4 ♜f7+ 70. ♔g4 h5+ 71. ♔h3"
  },
  {
    "id": 3,
    "whiteName": "Kasparov Garry",
    "blackName": "Karpov Anatoliy",
    "result": "1-0",
    "tournamentName": "World Chess Championship 1985",
    "moves": "1. d4 ♞f6 2. c4 e6 3. ♘c3 ♝b4 4. ♘f3 O‑O 5. ♗g5 c5 6. e3 cxd4 7. exd4 h6 8. ♗h4 d5 9. ♖c1 dxc4 10. ♗xc4 ♞c6 11. O‑O ♝e7 12. ♖e1 b6 13. a3 ♝b7 14. ♗g3 ♜c8 15. ♗a2 ♝d6 16. d5 ♞xd5 17. ♘xd5 ♝xg3 18. hxg3 exd5 19. ♗xd5 ♛f6 20. ♕a4 ♜fd8 21. ♖cd1 ♜d7 22. ♕g4 ♜cd8 23. ♕xd7 ♜xd7 24. ♖e8+ ♚h7 25. ♗e4+"
  },
  {
    "id": 4,
    "whiteName": "TestOne",
    "blackName": "TestTwo",
    "result": "0-1",
    "tournamentName": "TestTournamentName",
    "moves": "1. g4 e6 2. f3 Qh4#"
  }
]
*/
