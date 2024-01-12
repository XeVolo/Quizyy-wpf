using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Quizyy_wpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Quizyy_wpf.Controller
{
	public class ChooseController
	{
		private List<WriteModel> items = BaseController.GetWriteList();
		public List<int> GetNumbers()
		{
			Range xy = new Range(0, 3);
			int count = 4;
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
		public int GetRandom()
		{
			List<WriteModel> list = BaseController.GetWriteList();
			int size = list.Count;
			Random rnd = new Random();
			int result = rnd.Next(size);
			return result;
		}
		public bool AnsButtonClick(string ans,int index)
		{		
				return ans.Equals(items[index].answer);
		}
		public string DisplayQuestion(int index)
		{
			return items[index].question;
		}
	}
}
