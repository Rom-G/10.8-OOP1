using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankTask1.Helper_Classes
{
    public class RelayCommand : ICommand
    {
        #region Поля

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Поля

        #region Конструкторы

        /// <summary>
        /// Создает новую команду, которую всегда можно выполнить.
        /// </summary>
        /// <param name="execute">Логика выполнения.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Создаёт новую команду.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion // Конструкторы

        #region Члены интерфейса ICommand

        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }

        #endregion // Члены интерфейса ICommand
    }
}
