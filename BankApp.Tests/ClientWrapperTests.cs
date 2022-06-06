using BankApp.Model.Entities;
using BankApp.Model.ValueObjects;
using BankApp.UI.Models;
using NUnit.Framework;
using System;

namespace BankApp.Tests
{
    public class ClientWrapperTests
    {
        Client? _client;

        [SetUp]
        public void Setup()
        {
            _client = new Client("Alex", new Address("Россия", "Санкт-Петербург", "Подольская ул."));
        }

        [Test]
        public void ShouldContainModel()
        {
            var wrapper = new ClientModel(_client!);
            Assert.AreEqual(_client, wrapper.Model);
        }

        [Test]
        public void ShouldThrowAngumentNullException()
        {
            #pragma warning disable CS8625
            Assert.Throws<ArgumentNullException>(() =>
            {
                var wrapper = new ClientModel(null);
            });
            #pragma warning restore CS8625
        }

        [Test]
        public void ShouldSetValueOfModel()
        {
            var wrapper = new ClientModel(_client!)
            {
                Name = "Aleksandr"
            };

            Assert.AreEqual(wrapper.Name, "Aleksandr");
        }

        [Test]
        public void ShouldGetValueOfModel()
        {
            var wrapper = new ClientModel(_client!);
            Assert.AreEqual(wrapper.Name, _client!.Name);
            Assert.AreEqual(wrapper.SecondName, _client!.SecondName);
        }

        [Test]
        public void ShouldRaisePropertyChangedForName()
        {
            var propertyChangedFired = false;
            var wrapper = new ClientModel(_client!);
            wrapper.PropertyChanged += (s, e) =>
            {
                if(e.PropertyName == "Name")
                {
                    propertyChangedFired = true;
                }
            };
            wrapper.Name = "Aleksandr";
            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ShouldRaisePropertyChangedForSecondName()
        {
            var propertyChangedFired = false;
            var wrapper = new ClientModel(_client!);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "SecondName")
                {
                    propertyChangedFired = true;
                }
            };
            wrapper.SecondName = "Fomich";
            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ShouldRaisePropertyChangedForNameIsChanged()
        {
            var propertyChangedFired = false;
            var wrapper = new ClientModel(_client!);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "NameIsChanged")
                {
                    propertyChangedFired = true;
                }
            };
            wrapper.Name = "Aleksandr";
            Assert.IsTrue(propertyChangedFired);
        }

        [Test]
        public void ShouldNotRaisePropertyChangedNameIsSameValue()
        {
            var propertyChangedFired = false;
            var wrapper = new ClientModel(_client!);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Name")
                {
                    propertyChangedFired = true;
                }
            };
            wrapper.Name = "Alex";
            Assert.IsFalse(propertyChangedFired);
        }

        [Test]
        public void SouldStoreOriginalValue()
        {
            var wrapper = new ClientModel(_client!);
            Assert.AreEqual("Alex", wrapper.NameOriginalValue);
            wrapper.Name = "Sanya";
            Assert.AreEqual("Alex", wrapper.NameOriginalValue);
        }

        [Test]
        public void SouldSetNameIsChanged()
        {
            var wrapper = new ClientModel(_client!);
            Assert.IsFalse(wrapper.NameIsChanged);
            wrapper.Name = "Sanya";
            Assert.IsTrue(wrapper.NameIsChanged);
        }

        [Test]
        public void SouldNotSetNameIsChangedIfNameIsOriginal()
        {
            var wrapper = new ClientModel(_client!)
            {
                Name = "Sanya"
            };
            wrapper.Name = "Alex";
            Assert.IsFalse(wrapper.NameIsChanged);
        }
    }
}