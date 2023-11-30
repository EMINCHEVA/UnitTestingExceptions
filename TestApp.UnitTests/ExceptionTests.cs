using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "hello";
        string expected = "olleh";

        // Act
        string result = this._exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 10.0m;
        // Act
        decimal result = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        // Assert
        Assert.That(result, Is.EqualTo(90m));
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -10.0m;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = new[] { 1, 2, 3 };
        int index = 1;
        //Act
        int result = this._exceptions.IndexOutOfRangeGetElement(array, index);
        //Assert
        Assert.That(result, Is.EqualTo(2));
    }


    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = new[] { 1, 2, 3 };
        int index = -1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }


    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }


    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        /// Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length + 2;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }


    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool isLoggedIn = true;
        // Act
        string result = this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);
        // Assert 
        Assert.That(result, Is.EqualTo("User logged in."));

    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool isLoggedIn = false;
        // Act & Assert 
        Assert.That(() => this._exceptions.InvalidOperationPerformSecureOperation(isLoggedIn), Throws.InstanceOf<InvalidOperationException>());
    }


    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "3";
        // Act
        int result = this._exceptions.FormatExceptionParseInt(input);
        // Assert 
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "3. , abd";

        // Act & Assert 
        Assert.That(() => this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            ["first"] = 10,
            ["second"] = 15,
            ["third"] = 20,
        };

        string key = "second";

        // Act
        int result = this._exceptions.KeyNotFoundFindValueByKey(dictionary, key);
        // Assert 
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            ["first"] = 10,
            ["second"] = 15,
            ["third"] = 20,
        };
        string key = "fifth";
        // Act & Assert
        Assert.That(() => this._exceptions.KeyNotFoundFindValueByKey(dictionary, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int num1 = 2;
        int num2 = 3;
        // Act
        int result = this._exceptions.OverflowAddNumbers(num1, num2);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange  /// Pos.overflow znachi tarsim dost golemi chisla blizo do gorna granitsa  na int ili da vzemem naj-golq. st-st =. Maxvalue
        int num1 = int.MaxValue;
        int num2 = int.MaxValue;
        // Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(num2, num1), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange  /// Neg overflow znachi tarsim dost golemi chisla blizo do gorna granitsa  na int ili da vzemem naj-malka. st-st =. MinValue
        int num1 = int.MinValue;
        int num2 = int.MinValue;
        // Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(num2, num1), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int num1 = 6;
        int num2 = 3;
        // Act
        int result = this._exceptions.DivideByZeroDivideNumbers(num1, num2);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // // Arrange
        int num1 = 6;
        int num2 = 0;
        // Act and Assert
        Assert.That(() => this._exceptions.DivideByZeroDivideNumbers(num1, num2), Throws.InstanceOf<DivideByZeroException>());

    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] collection = new int[] { 1, 2, 3 };
        int index = 2;

        //Act
        int result = this._exceptions.SumCollectionElements(collection, index);
        // Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrnage
        int[]? collection = null;
        int index = 2;

        //Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(collection, index), Throws.ArgumentNullException);

    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {

        // Arrnage
        int[]? collection = { 1, 2, 3 }; ;
        int index = 5;

        //Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(collection, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> collection = new()
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3",
        };

        string key = "first";
        // Act
        int result = this._exceptions.GetElementAsNumber(collection, key);
        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> collection = new()
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3",
        };
        string key = "seventh";

        // Act & Assert 
        Assert.That(() => this._exceptions.GetElementAsNumber(collection, key), Throws.InstanceOf<KeyNotFoundException>());
    }
       
        [Test]
        public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
        {
        // Arrange
        Dictionary<string, string> collection = new()
        {
            ["first"] = "1sde",
            ["second"] = "baba2",
            ["third"] = "3zoa",
        };
        string key = "second";

        // Act & Assert 
        Assert.That(() => this._exceptions.GetElementAsNumber(collection, key), Throws.InstanceOf<FormatException>());

    }
    
}
