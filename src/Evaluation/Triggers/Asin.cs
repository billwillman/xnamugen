using System;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("Asin")]
	internal static class Asin
	{
		public static float Evaluate(object state, ref bool error, float value)
		{
			if (value < -1 || value > 1)
			{
				error = true;
				return 0;
			}

			return (float)Math.Asin(value);
		}

		public static Node Parse(ParseState state)
		{
			return state.BuildParenNumberNode(true);
		}
	}
}
