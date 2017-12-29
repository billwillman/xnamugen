namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("BackEdgeDist")]
	internal static class BackEdgeDist
	{
		public static int Evaluate(object state, ref bool error)
		{
			var character = state as Combat.Character;
			if (character == null)
			{
				error = true;
				return 0;
			}

			var camerarect = character.Engine.Camera.ScreenBounds;
			var stage = character.Engine.Stage;

			switch (character.CurrentFacing)
			{
				case xnaMugen.Facing.Left:
					return camerarect.Right - character.GetRightEdgePosition(false);

				case xnaMugen.Facing.Right:
					return character.GetLeftEdgePosition(false) - camerarect.Left;

				default:
					error = true;
					return 0;
			}
		}

		public static Node Parse(ParseState state)
		{
			return state.BaseNode;
		}
	}
}
