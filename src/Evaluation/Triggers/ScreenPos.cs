using Microsoft.Xna.Framework;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("ScreenPos")]
	internal static class ScreenPos
	{
		public static float Evaluate(object state, ref bool error, Axis axis)
		{
			var character = state as Combat.Character;
			if (character == null)
			{
				error = true;
				return 0;
			}

			var drawlocation = character.GetDrawLocation() - (Vector2)character.Engine.Camera.Location;

			switch (axis)
			{
				case Axis.X:
					return drawlocation.X;

				case Axis.Y:
					return drawlocation.Y;

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
