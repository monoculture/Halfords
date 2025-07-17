namespace Halfords.TechTest
{
	internal class ElementWordSolver
	{
		public static List<List<string>> Solve(string word)
		{
			var output = new List<List<string>>();

			Search(word, 0, [], output);

			return output;
		}

		private static void Search(
			string word,
			int wordPosition,
			List<string> candidate,
			List<List<string>> output)
		{
			if (wordPosition >= word.Length)
				output.Add(candidate);

			for (var i = 1; i <= 2; i++)
			{
				var nextCandidate = GetNextCandidate(word, wordPosition, candidate, i);

				if(nextCandidate != null)
					Search(word, wordPosition + i, nextCandidate, output);
			}
		}

		private static List<string>? GetNextCandidate(string word, int wordPosition, List<string> candidate, int take)
		{
			if(wordPosition + take > word.Length)
				return null;

			var substring = word.Substring(wordPosition, take); 
			
			var element = ElementLookup.GetElement(substring);

			if (element == null)
			{
				return null;
			}

			var newCandidate = new List<string>();

			newCandidate.AddRange(candidate);

			newCandidate.Add(element);

			return newCandidate;
		}
	}
}
