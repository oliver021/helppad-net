using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Helppad.Algorithms
{
    /// <summary>
    /// Units category types to express the units of measurement.
    /// like:
    ///     - Length
    ///     - Mass
    ///     - Time
    ///     - Temperature
    ///     - Electric Current
    ///     - Amount of Substance
    ///     - Luminous Intensity
    /// </summary>
    public enum UnitsTypes{
        Length,
        Mass,
        Time,
        Temperature,
        ElectricCurrent,
        AmountOfSubstance,
        Information,
        Power,
        Pressure,
        Energy,
        Volume,
        Angle,
        Area,
        Radioactivity,
        Sound
    }

    /// <summary>
    /// Units of Length.
    /// </summary>
    public enum LengthUnits{
        Meter,
        Centimeter,
        Millimeter,
        Kilometer,
        Inch,
        Yard,
        Foot,
        Mile,
        NauticalMile
    }

    public enum MassUnits{
        Kilogram,
        Gram,
        Milligram,
        Ton,
        Ounce,
        Pound,
        Stone,
        Slug,
        Decagram
    }

    /// <summary>
    /// Units of Time.
    /// </summary>
    public enum TimeUnits{
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year,
        Decade,
        Century,
        Millenium,
        Millisecond,
        Microsecond,
        Nanosecond
    }

    /// <summary>
    /// Units of Temperature.
    /// </summary>
    public enum TemperatureUnits{
        Kelvin,
        Celsius,
        Fahrenheit,
        Rankine
    }

    /// <summary>
    /// Units of Electric Current.
    public enum ElectricCurrentUnits{
        Ampere,
        Milliampere,
        Microampere,
        Nanoampere
    }

    /// <summary>
    /// Units of Amount of Substance.
    /// </summary>
    public enum AmountOfSubstanceUnits{
        Mole,
        Millimole,
        Micromole,
        Nanomole
    }

    /// <summary>
    /// Units of Information.
    /// </summary>
    public enum InformationUnits{
        Bit,
        Byte,
        Kilobyte,
        Megabyte,
        Gigabyte,
        Terabyte,
        Petabyte,
        Exabyte,
        Zettabyte,
        Yottabyte
    }

    /// <summary>
    /// Units of Power.
    /// </summary>
    public enum PowerUnits{
        Watt,
        Milliwatt,
        Microwatt,
        Nanowatt,
        Kilowatt,
        Megawatt,
        Gigawatt,
        Terawatt,
        Petawatt,
        Exawatt
    }

    /// <summary>
    /// Units of Pressure.
    /// </summary>
    public enum PressureUnits{
        Pascal,
        Bar,
        Millibar,
        Centibar,
        Decibar,
        Kilobar,
        Megabar,
        Hectobar,
        Kilopascal,
        Megapascal
    }

    /// <summary>
    /// Units of Energy.
    /// </summary>
    public enum EnergyUnits{
        Joule,
        Millijoule,
        Microjoule,
        Kilojoule,
        Megajoule,
        Gigajoule,
        Terajoule
    }

    /// <summary>
    /// Units of Volume.
    /// </summary>
    public enum VolumeUnits{
        Liter,
        Milliliter,
        Centiliter,
        Deciliter,
        Kiloliter,
        Hectoliter,
        Megaliter,
        Gigaliter
    }

    /// <summary>
    /// Units of Angle.
    /// </summary>
    public enum AngleUnits{
        Degree,
        Radian,
        Gradian,
        Revolution
    }

    /// <summary>
    /// Units of Area.
    /// </summary>
    public enum AreaUnits{
        SquareMeter,
        SquareKilometer,
        SquareCentimeter,
        SquareMillimeter,
        SquareInch,
        SquareFoot,
        SquareYard,
        SquareMile,
        SquareNauticalMile
    }

    /// <summary>
    /// Units of Radioactivity.
    /// </summary>
    public enum RadioactivityUnits{
        Curie,
        Millicurie,
        Microcurie,
        NanoCurie,
        Becquerel,
        Millibecquerel,
        Microbecquerel,
        Nanobecquerel,
        Gray,
        Sievert,
        Roentgen
    }

    /// <summary>
    /// Units of Sound.
    /// </summary>
    public enum SoundUnits{
        Hertz,
        MilliHertz,
        MicroHertz,
        NanoHertz,
        KiloHertz,
        MegaHertz,
        GigaHertz,
        TeraHertz,
        DeciHertz,
        CentiHertz
    }

    /// <summary>
    /// Class to convert units of measurement.
    /// </summary>
    public static class UnitsConveter
    {
        /// <summary>
        /// Convert a value from one unit to another.
        /// Works with Length units.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="from">Unit to convert from.</param>
        /// <param name="to">Unit to convert to.</param>
        /// <returns>Converted value.</returns>
        public static double ConvertLength(double value, LengthUnits from, LengthUnits to)
        {
            // validate units from and to: must be different
            // otherwise does not make sense
            if(from == to)
                throw new ArgumentException("Units must be different.");

            /* The algorithm is take the passed value to the minimum unit
                and then convert to the desired unit. */

            // this variable will hold the value of the unit to convert from smallest unit
            double minimumUnit = 0;

            // switch convert value to the smallest unit
            // minimumUnit: minimeter
            // convert every case to minimeter
            switch(from)
            {
                case LengthUnits.Meter:
                    minimumUnit = value * 1000;
                    break;

                case LengthUnits.Centimeter:
                    minimumUnit = value * 10;
                    break;
                
                case LengthUnits.Millimeter:
                    minimumUnit = value;
                    break;

                case LengthUnits.Kilometer:
                    minimumUnit = value * 1000 * 1000;
                    break;

                case LengthUnits.Inch:
                    minimumUnit = value * 25.4;
                    break;

                case LengthUnits.Yard:
                    minimumUnit = value * 914.4;    
                    break;

                case LengthUnits.Foot:
                    minimumUnit = value * 304.8;
                    break;

                case LengthUnits.Mile:
                    minimumUnit = value * 1609344;
                    break;

                case LengthUnits.NauticalMile:
                    minimumUnit = value * 1852 * 1000;
                    break;

                default:
                    throw new Exception("Invalid unit to convert from.");

            }

            // convert from the smallest unit to the desired unit
            // now return the value in the desired unit
            switch(to)
            {
                case LengthUnits.Meter:
                    return minimumUnit / 1000;

                case LengthUnits.Centimeter:
                    return minimumUnit / 10;

                case LengthUnits.Millimeter:
                    return minimumUnit;

                case LengthUnits.Kilometer:
                    return minimumUnit / 1000 / 1000;

                case LengthUnits.Inch:
                    return minimumUnit / 25.4;

                case LengthUnits.Yard:
                    return minimumUnit / 914.4;

                case LengthUnits.Foot:
                    return minimumUnit / 304.8;

                case LengthUnits.Mile:
                    return minimumUnit / 1609344;

                case LengthUnits.NauticalMile:
                    return minimumUnit / 1852 / 1000;

                default:
                    throw new Exception("Invalid unit to convert from.");
            }

        }

        /// <summary>
        /// Convert a value from one unit to another.
        /// Works with Mass units.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="from">Unit to convert from.</param>
        /// <param name="to">Unit to convert to.</param>
        /// <returns>Converted value.</returns>
        public static double ConvertMass(double value, MassUnits from, MassUnits to)
        {
            // validate units from and to: must be different
            // otherwise does not make sense
            if(from == to)
                throw new ArgumentException("Units must be different.");
            
            /* The algorithm is take the passed value to the minimum unit
                and then convert to the desired unit. */

            // this variable will hold the value of the unit to convert from smallest unit
            double minimumUnit = 0;

            // switch convert value to the smallest unit
            // minimumUnit: miligram
            // convert every case to miligram
            switch(from)
            {
                case MassUnits.Gram:
                    minimumUnit = value * 1000;
                    break;

                case MassUnits.Decagram:
                    minimumUnit = value * 10;
                    break;
                
                case MassUnits.Milligram:
                    minimumUnit = value;
                    break;
                
                case MassUnits.Kilogram:
                    minimumUnit = value * 1000 * 1000;
                    break;
                
                case MassUnits.Ton:
                    minimumUnit = value * 1000 * 1000 * 1000;
                    break;
                
                case MassUnits.Ounce:
                    minimumUnit = value * 28.3495;
                    break;
                
                case MassUnits.Pound:
                    minimumUnit = value * 453.592;
                    break;
                
                case MassUnits.Stone:
                    minimumUnit = value * 6350.29;
                    break;
                
                default:
                    throw new Exception("Invalid unit to convert from.");
            }

            // convert from the smallest unit to the desired unit
            // now return the value in the desired unit
            switch(to)
            {
                case MassUnits.Gram:
                    return minimumUnit / 1000;

                case MassUnits.Decagram:
                    return minimumUnit / 10;

                case MassUnits.Milligram:
                    return minimumUnit;

                case MassUnits.Kilogram:
                    return minimumUnit / 1000 / 1000;

                case MassUnits.Ton:
                    return minimumUnit / 1000 / 1000 / 1000;

                case MassUnits.Ounce:
                    return minimumUnit / 28.3495;

                case MassUnits.Pound:
                    return minimumUnit / 453.592;

                case MassUnits.Stone:
                    return minimumUnit / 6350.29;

                default:
                    throw new Exception("Invalid unit to convert to.");
            }
        }

        /// <summary>
        /// Convert a value from one unit to another.
        /// Works with Time units.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="from">Unit to convert from.</param>
        /// <param name="to">Unit to convert to.</param>
        /// <returns>Converted value.</returns>
        public static double ConvertTime(double value, TimeUnits from, TimeUnits to)
        {
            // validate units from and to: must be different
            // otherwise does not make sense
            if(from == to)
                throw new ArgumentException("Units must be different.");

            /* The algorithm is take the passed value to the minimum unit
                and then convert to the desired unit. */

            // this variable will hold the value of the unit to convert from smallest unit
            double minimumUnit = 0;

            // switch convert value to the smallest unit
            // minimumUnit: nanosecond
            // convert every case to nanosecond
            switch(from)
            {
                case TimeUnits.Second:
                    minimumUnit = value * 1000000000;
                    break;
                
                case TimeUnits.Millisecond:
                    minimumUnit = value * 1000000;
                    break;

                case TimeUnits.Microsecond:
                    minimumUnit = value * 1000;
                    break;

                case TimeUnits.Nanosecond:
                    minimumUnit = value;
                    break;
                    
                case TimeUnits.Minute:
                    minimumUnit = value * 60 * 1000000000;
                    break;
                
                case TimeUnits.Hour:
                    minimumUnit = value * 60 * 60 * 1000000000;
                    break;
                
                case TimeUnits.Day:
                    minimumUnit = value * 24 * 60 * 60 * 1000000000;
                    break;
                
                case TimeUnits.Week:
                    minimumUnit = value * 7 * 24 * 60 * 60 * 1000000000;
                    break;
                
                case TimeUnits.Month:
                    minimumUnit = value * 30.417 * 24 * 60 * 60 * 1000000000;
                    break;
                
                case TimeUnits.Year:
                    minimumUnit = value * 365.242 * 30.417 * 24 * 60 * 60 * 1000000000;
                    break;

                default:
                    throw new Exception("Invalid unit to convert to.");
            }

            // convert from the smallest unit to the desired unit
            // now return the value in the desired unit
            switch(to)
            {
                case TimeUnits.Second:
                    return minimumUnit / 1000000000;

                case TimeUnits.Millisecond:
                    return minimumUnit / 1000000;

                case TimeUnits.Microsecond:
                    return minimumUnit / 1000;
                
                case TimeUnits.Nanosecond:
                    return minimumUnit;

                case TimeUnits.Minute:
                    return minimumUnit / 60 / 1000000000;

                case TimeUnits.Hour:
                    return minimumUnit / 60 / 60 / 1000000000;

                case TimeUnits.Day:
                    return minimumUnit / 24 / 60 / 60 / 1000000000;

                case TimeUnits.Week:
                    return minimumUnit / 7 / 24 / 60 / 60 / 1000000000;

                case TimeUnits.Month:
                    return minimumUnit / 30.417 / 24 / 60 / 60 / 1000000000;

                case TimeUnits.Year:
                    return minimumUnit / 365.242 / 30.417 / 24 / 60 / 60 / 1000000000;

                default:
                    throw new Exception("Invalid unit to convert to.");
            }
        }

        /// <summary>
        /// Convert a value from one unit to another.
        /// Works with Temperature units.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="from">Unit to convert from.</param>
        /// <param name="to">Unit to convert to.</param>
        /// <returns>Converted value.</returns>
        public static double ConvertTemperature(double value, TemperatureUnits from, TemperatureUnits to)
        {
            // validate units from and to: must be different
            // otherwise does not make sense
            if(from == to)
                throw new ArgumentException("Units must be different.");

            /* The algorithm is take the passed value to the minimum unit
                and then convert to the desired unit. */

            // this variable will hold the value of the unit to convert from smallest unit
            double minimumUnit = 0;

            // switch convert value to the smallest unit
            // minimumUnit: Kelvin
            // convert every case to Kelvin
            switch(from)
            {
                case TemperatureUnits.Celsius:
                    minimumUnit = value + 273.15;
                    break;

                case TemperatureUnits.Fahrenheit:
                    minimumUnit = (value + 459.67) * 5 / 9;
                    break;

                case TemperatureUnits.Kelvin:
                    minimumUnit = value;
                    break;

                default:
                    throw new Exception("Invalid unit to convert from.");
            }

            // convert from the smallest unit to the desired unit
            // now return the value in the desired unit
            switch(to)
            {
                case TemperatureUnits.Celsius:
                    return minimumUnit - 273.15;

                case TemperatureUnits.Fahrenheit:
                    return (minimumUnit * 9 / 5) - 459.67;

                case TemperatureUnits.Kelvin:
                    return minimumUnit;

                default:
                    throw new Exception("Invalid unit to convert to.");
            }
        }
    }
}