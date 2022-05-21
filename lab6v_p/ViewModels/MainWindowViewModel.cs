using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using lab6v_p.Models;

namespace lab6v_p.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<DailyPlanner> ItemsAll { get; set; }

        ViewModelBase content;
        public MainWindowViewModel()
        {
            Button_Add = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    var newItem = new DailyPlanner("", "", fvm.CurrentDate);
                    var svm = new SecondViewModel(newItem);
                    Observable.Merge(
                svm.OK,
                svm.Cancel.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    ItemsAll.Add(newItem);
                    fvm.changeItems();
                    Content = fvm;
                });
                    Content = svm;
                    return Unit.Default;
                });
            Button_Zoom = ReactiveCommand.Create<DailyPlanner, Unit>(
                (item) =>
                {
                    var svm = new SecondViewModel(item);
                    Observable.Merge(
                svm.OK,
                svm.Cancel.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    fvm.changeItems();
                    Content = fvm;
                });
                    Content = svm;
                    return Unit.Default;
                });
            Button_Delete = ReactiveCommand.Create<DailyPlanner, Unit>((item) =>
            {
                ItemsAll.Remove(item);
                fvm.changeItems();
                return Unit.Default;
            });
            ItemsAll = BuildAllPlans();
            Content = fvm = new FirstViewModel(ItemsAll);
        }
        public ViewModelBase Content
        {
            set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }
        public FirstViewModel fvm
        {
            get;
        }
        public ReactiveCommand<Unit, Unit> Button_Add { get; }
        public ReactiveCommand<DailyPlanner, Unit> Button_Delete { get; }
        public ReactiveCommand<DailyPlanner, Unit> Button_Ok { get; }
        public ReactiveCommand<DailyPlanner, Unit> Button_Cancel { get; }
        public ReactiveCommand<DailyPlanner, Unit> Button_Zoom { get; }
        private List<DailyPlanner> BuildAllPlans()
        {
            return new List<DailyPlanner>
            {
                new DailyPlanner("ТерВер-зачёт","Получить зачёт по ТерВеру", DateTime.Today.AddDays(0)),
                new DailyPlanner("Еда","Приготовить салат", DateTime.Today.AddDays(0)),
     
                new DailyPlanner("РГР","Доделать РГР", DateTime.Today.AddDays(-1)),
             
                new DailyPlanner("Практика","Защитить курсовую по практике", DateTime.Today.AddDays(1)),
                new DailyPlanner("Поездка","Поехать домой", DateTime.Today.AddDays(1)),
                new DailyPlanner("Телефон","Купить новый телефон", DateTime.Today.AddDays(1)),
            };
        }
    }
}