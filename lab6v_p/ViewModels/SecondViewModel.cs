using System.Reactive;
using ReactiveUI;
using lab6v_p.Models;

namespace lab6v_p.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel(DailyPlanner item)
        {
            Name = item.Name;
            Todo = item.Todo;
            var okEnabled = this.WhenAnyValue(
                    x => x.Name,
                    x => !string.IsNullOrWhiteSpace(x));

            OK = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    item.Name = Name;
                    item.Todo = Todo;
                    return Unit.Default;
                }, okEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }
        string name;
        string todo;
        public string Name
        {
            get { return name; }
            set { this.RaiseAndSetIfChanged(ref name, value); }
        }
        public string Todo
        {
            get { return todo; }
            set { this.RaiseAndSetIfChanged(ref todo, value); }
        }
        public ReactiveCommand<Unit, Unit> OK { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}