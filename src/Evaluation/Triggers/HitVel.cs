namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("HitVel")]
	internal static class HitVel
	{
		public static float Evaluate(object state, ref bool error, Axis axis)
		{
			var character = state as Combat.Character;
			if (character == null)
			{
				error = true;
				return 0;
			}

			switch (axis)
			{
				case Axis.X:
					return character.DefensiveInfo.GetHitVelocity().X;

				case Axis.Y:
					return character.DefensiveInfo.GetHitVelocity().Y;

				default:
					error = true;
					return 0;
			}
		}

		public static Node Parse(ParseState parsestate)
		{
			var axis = parsestate.ConvertCurrentToken<Axis>();
			if (axis == Axis.None) return null;

			++parsestate.TokenIndex;

			parsestate.BaseNode.Arguments.Add(axis);
			return parsestate.BaseNode;
		}
	}
}
