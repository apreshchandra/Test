using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Functions
/// </summary>
public class Functions
{

    /// <summary>
    /// DBNull Constant
    /// </summary>
    public static string DBNull
    {
        get { return "{__NULL__}"; }
    }

    #region Bool
    /// <summary>
    /// Returns the boolean representation of the value.
    /// </summary>
    /// <param name="Value">Value that needs to be converted.</param>
    /// <returns>Boolean value.</returns>
    public static bool CBool(object Value)
    {
        return CBool(Value, false);
    }

    /// <summary>
    /// Returns the boolean representation of the value.
    /// </summary>
    /// <param name="Value">Value that needs to be converted.</param>
    /// <param name="DefaultValue">Default return value if value is null.</param>
    /// <returns>Boolean value.</returns>
    public static bool CBool(object Value, bool DefaultValue)
    {
        try
        {
            if (Value == null || Value is System.DBNull || Value.ToString() == Functions.DBNull) return DefaultValue;

            switch (Value.ToString().Trim().ToUpper())
            {
                case "A":
                case "Y":
                case "T":
                case "TRUE":
                    return true;

                case "I":
                case "N":
                case "F":
                case "FALSE":
                    return false;
            }
        }
        catch (FormatException)
        {
            return DefaultValue;
        }
        catch (ArgumentException)
        {
            return DefaultValue;
        }
        catch (OverflowException)
        {
            return DefaultValue;
        }

        return DefaultValue;
    }
    #endregion


}