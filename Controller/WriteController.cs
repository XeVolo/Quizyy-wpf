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
	public class WriteController
	{
		private List<WriteModel> items = BaseController.GetWriteList();
		private int index = 0;

		public void PreviousButtonClick()
		{
			if (index > 0)
			{
				index--;
				
			}
			else if (index == 0)
			{
				index = items.Count - 1;
				
			}
		}

		public void NextButtonClick()
		{
			if (index < items.Count - 1)
			{
				index++;
				
			}
			else if (index >= items.Count - 1)
			{
				index = 0;
				
			}
		}
		public string ContextButtonClick(string ans)
		{
			ans = ans.ToLower();
			bool correctness = ans.Equals(items[index].answer.ToLower());
			if (correctness)
			{

				
				index++;
				if (index >= items.Count - 1) index = 0;

				return "Odpowiedź prawidłowa";
			}
			else
			{
				
				return "Odpowiedź błędna";
			}
		}
		public string DisplayQuestion()
		{
			return items[index].question;
		}
	}
}
