using Microsoft.VisualBasic.FileIO;
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

    public class FlashCardsController	
    {
		List<FlashCardsModel> items = BaseController.GetFlashCardsList();
		private int currentIndex = 1;
		private int control = 0;

		public void PreviousButtonClick()
		{
			if (currentIndex > 0)
			{
				currentIndex--;				
			}
			else if (currentIndex == 0)
			{
				currentIndex = items.Count - 1;
			}
		}

		public void NextButtonClick()
		{
			if (currentIndex < items.Count - 1)
			{
				currentIndex++;
			}
			else if (currentIndex == items.Count - 1)
			{
				currentIndex = 0;
			}
		}
		public string ContextButtonClick()
		{
			if (control == 1)
			{
				control = 0;
				return  items[currentIndex].definition;
				
			}
			else
			{
				control = 1;
				return items[currentIndex].concept;
				
			}
		}

		public string DisplayCurrentItem()
		{
			if (items.Count > 0 && currentIndex >= 0 && currentIndex < items.Count)
			{
				control = 1;
				return items[currentIndex].concept;				
			}
			return "";
		}
	}
}
