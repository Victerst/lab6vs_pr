using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using lab6v_p.Models;

namespace lab6v_p.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        public FirstViewModel(List<DailyPlanner> ItemsAll)
        {
            itemsAll = ItemsAll;
            currentDate = DateTime.Today;
            changeItems();
        }
        public void changeItems()
        {
            items.Clear();
            foreach (var item in itemsAll)
            {
                if (item.Date.Equals(CurrentDate)) items.Add(item);
            }
            ItemsSelected = new ObservableCollection<DailyPlanner>(items);
        }

        public ObservableCollection<DailyPlanner> itemsSelected;
        public ObservableCollection<DailyPlanner> ItemsSelected
        {
            get
            {
                return itemsSelected;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref itemsSelected, value);
            }
        }

        private List<DailyPlanner> items = new List<DailyPlanner>();
        private List<DailyPlanner> itemsAll;
        DateTimeOffset currentDate;
        public DateTimeOffset CurrentDate
        {
            get { return currentDate; }
            set
            {
                this.RaiseAndSetIfChanged(ref currentDate, value);
                changeItems();
            }
        }
    }
}