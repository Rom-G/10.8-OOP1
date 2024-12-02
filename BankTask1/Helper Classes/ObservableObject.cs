using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTask1.Helper_Classes
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region Участники INotifyPropertyChanged

        /// <summary>
        /// Возникает, когда меняется свойство указанного объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для указанного объекта.
        /// </summary>
        /// <param name="propertyName">Свойство, которое имеет новое значение.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            if (this.PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, e);
            }
        }

        #endregion // Участники INotifyPropertyChanged

        #region Помощники по отладке

        /// <summary>
        /// Предупреждает разработчика, если у этого объекта нет
        /// общедоступного свойства с указанным именем. Этот
        /// метод не существует в сборке выпуска.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public virtual void VerifyPropertyName(string propertyName)
        {
            // Проверка того, что имя свойства соответствует реальному,
            // общедоступному свойству экземпляра этого объекта.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Возвращает, вызвано ли исключение или используется функция Debug.Fail()
        /// когда методу VerifyPropertyName передается недопустимое имя свойства.
        /// Значение по умолчанию равно false, но подклассы, используемые модульными тестами, могут
        /// переопределять метод получения этого свойства, возвращая значение true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Помощники по отладке
    }
}
