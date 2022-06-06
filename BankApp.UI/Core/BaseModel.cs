using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BankApp.UI.Core
{
    public class BaseModel<TModel> : Bindable, IChangeTracking where TModel : class
    {
        /// <summary>
        /// Изменилась ли модель
        /// </summary>
        public bool IsChanged => _originalValues.Any();

        private readonly Dictionary<string, object> _originalValues;

        /// <summary>
        /// Модель данных
        /// </summary>
        public TModel Model { get; set; }

        public BaseModel(TModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            _originalValues = new Dictionary<string, object>();
        }

        /// <summary>
        /// Установливает значение свойства модели и уведомляет UI
        /// </summary>
        /// <typeparam name="TValue">Тип устанавливаемого значения</typeparam>
        /// <param name="value">Новое значение свойства</param>
        /// <param name="propertyName">Имся устанавливаемого свойства</param>
        protected void SetValue<TValue>(TValue value, [CallerMemberName] string? propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName!);
            var currentValue = propertyInfo?.GetValue(Model, null);
            if (!Equals(currentValue, value))
            {
                UpdateOriginalValue(currentValue, value, propertyName);
                propertyInfo?.SetValue(Model, value, null);
                OnPropertyChanged(propertyName);
                OnPropertyChanged($"{propertyName}IsChanged");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        private void UpdateOriginalValue(object? currentValue, object? newValue, string? propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName!))
            {
                _originalValues.Add(propertyName!, currentValue!);
                OnPropertyChanged($"IsChanged");
            }
            else
            {
                if(_originalValues.ContainsKey(propertyName!))
                {
                    _originalValues.Remove(propertyName!);
                    OnPropertyChanged($"IsChanged");
                }
            }
        }

        /// <summary>
        /// Получает значение свойства модели
        /// </summary>
        /// <typeparam name="TValue">Тип обновляемого свойства</typeparam>
        /// <param name="propertyName">Имя обновляемого свойства</param>
        /// <returns></returns>
        protected TValue GetValue<TValue>([CallerMemberName] string? propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName!);
            var currentValue = propertyInfo?.GetValue(Model, null);
            return (TValue)currentValue!;
        }

        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            if (_originalValues.ContainsKey(propertyName))
            {
                return (TValue)_originalValues[propertyName];
            }
            else
            {
                return GetValue<TValue>(propertyName);
            }
        }

        protected bool GetIsChanged(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName);
        }

        public void AcceptChanges()
        {
            _originalValues.Clear();
        }
    }
}
