using System.Text.Json;

namespace CaseStudy.Models
{
	public static class SessionExtensions
	{
		public static void SetObject<T>(this ISession session,
		   string key, T value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static T? GetObject<T>(this ISession session, string key)
		{
			var json = session.GetString(key);
			if (string.IsNullOrEmpty(json))
			{
				return default(T);
			}
			else
			{
				return JsonSerializer.Deserialize<T>(json);
			}
		}
	}

	//public class GameSession
	//{
	//	private const string GameKey = "pigGame";

	//	private ISession session;
	//	public GameSession(ISession sess) => session = sess;
	//	public Game GetGame() => session.GetObject<Game>(GameKey) ?? new Game();

	//	public void SetGame(Game game) => session.SetObject(GameKey, game);
	//}
}
