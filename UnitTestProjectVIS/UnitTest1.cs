using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VISwpf;

namespace UnitTestProjectVIS
{
    [TestClass]
    public class UnitTest1
    {
        AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
        [TestMethod]
        public void TestMethodEmptyField()
        {
            

            string fName = "";
            string lName = "";
            string mName = "";

            //проверка имени сотрудника на заполнение
            Assert.IsFalse(addEmployeeWindow.validationNames(fName, AddEmployeeWindow.TypesField.FIRST));
            //проверка фамилии сотрудника на заполнение
            Assert.IsFalse(addEmployeeWindow.validationNames(lName, AddEmployeeWindow.TypesField.LAST));
            //проверка отчества сотрудника на заполнение
            Assert.IsFalse(addEmployeeWindow.validationNames(mName, AddEmployeeWindow.TypesField.MIDDLE));
            

        }

        [TestMethod]
        public void TestMethodRegexField()
        {
            string fmName1 = "qwe";//проверка на недопустимость английских букв
            string fmName2 = "123";//проверка на недопустимость цифр
            string fmName3 = "ёЁаяАЯ";//проверка на содержание символов
            string fmName4 = "№!№;%:";//проверка на недопустимость символов
            string fmName5 = "гггггггггггггггггггггггггггггг";//проверка на соответствие равенства 30 символам(имя и отчество)
            string fmName6 = "ггггггггггггггггггггггггггггггг";//превышение лимита символов(31 символ)(имя и отчество)
            string lName1 = "гггггггггггггггггггг";//проверка на соответствие равенства 20 символам(фамилия)
            string lName2 = "ггггггггггггггггггггг";//превышение лимита символов(21 символ)(фамилия)
            string fmName7 = "г";//минимально допустимый размер строки

            Assert.IsFalse(addEmployeeWindow.validationNames(fmName1, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName1, AddEmployeeWindow.TypesField.LAST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName1, AddEmployeeWindow.TypesField.MIDDLE));

            Assert.IsFalse(addEmployeeWindow.validationNames(fmName2, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName2, AddEmployeeWindow.TypesField.LAST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName2, AddEmployeeWindow.TypesField.MIDDLE));

            Assert.IsTrue(addEmployeeWindow.validationNames(fmName3, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsTrue(addEmployeeWindow.validationNames(fmName3, AddEmployeeWindow.TypesField.LAST));
            Assert.IsTrue(addEmployeeWindow.validationNames(fmName3, AddEmployeeWindow.TypesField.MIDDLE));

            Assert.IsFalse(addEmployeeWindow.validationNames(fmName4, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName4, AddEmployeeWindow.TypesField.LAST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName4, AddEmployeeWindow.TypesField.MIDDLE));

            Assert.IsTrue(addEmployeeWindow.validationNames(fmName5, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsTrue(addEmployeeWindow.validationNames(lName1, AddEmployeeWindow.TypesField.LAST));
            Assert.IsTrue(addEmployeeWindow.validationNames(fmName5, AddEmployeeWindow.TypesField.MIDDLE));

            Assert.IsFalse(addEmployeeWindow.validationNames(fmName6, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsFalse(addEmployeeWindow.validationNames(lName2, AddEmployeeWindow.TypesField.LAST));
            Assert.IsFalse(addEmployeeWindow.validationNames(fmName6, AddEmployeeWindow.TypesField.MIDDLE));

            Assert.IsTrue(addEmployeeWindow.validationNames(fmName7, AddEmployeeWindow.TypesField.FIRST));
            Assert.IsTrue(addEmployeeWindow.validationNames(fmName7, AddEmployeeWindow.TypesField.LAST));
            Assert.IsTrue(addEmployeeWindow.validationNames(fmName7, AddEmployeeWindow.TypesField.MIDDLE));


        }

        
    }
}
