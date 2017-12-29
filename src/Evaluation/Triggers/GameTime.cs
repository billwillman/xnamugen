namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("GameTime")]
	internal static class GameTime
	{
		public static int Evaluate(object state, ref bool error)
		{
			var character = state as Combat.Character;
			if (character == null)
			{
				error = true;
				return 0;
			}

			return character.Engine.TickCount;
		}

		public static Node Parse(ParseState state)
		{
			return state.BaseNode;
		}
	}
}
