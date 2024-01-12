using Quizyy_wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Reflection.Metadata;

namespace Quizyy_wpf.Controller
{
    public class FitController
    {

		public int GetRandom()
		{
			List<FlashCardsModel> lista = BaseController.GetFlashCardsList();
			int size = lista.Count - 7;
			Random rnd = new Random();
			int result = rnd.Next(size);
			return result;
		}
		public List<int> GetNumbers(Range xy)
		{
			int count = 7;
			Random rnd = new Random();
			List<int> numbers = new List<int>();

			while (numbers.Count < count)
			{
				int liczba = rnd.Next(xy.Start.Value, xy.End.Value + 1);
				if (!numbers.Contains(liczba))
				{
					numbers.Add(liczba);
				}
			}

			return numbers;
		}
	}
}
