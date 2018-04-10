﻿// Uncomment exactly one of the offered samples:

//#define Sample01SimpleBlinker
//#define Sample01SimpleBlinkerDistributed
//#define Sample01SimpleBlinkerAlternating
//#define Sample02ButtonControlsLampPolling
//#define Sample02ButtonControlsLampPollingInvertingButton
//#define Sample02ButtonControlsLampPollingInvertingLamp
#define Sample02ButtonControlsLampUsing2Buttons
//#define Sample03ButtonControlsLampEventBased
//#define Sample03ButtonControlsLampEventBasedInvertingButton
//#define Sample04SmoothPwmBlinker

namespace AbstractIO.Netduino3.Samples
{


    /// <summary>
    /// This class runs the abstract samples in AbstractIO.Samples on a Netduino 3 board.
    /// </summary>
    public static class Netduino3SamplesMain
    {
        /// <summary>
        /// Runs one of the abstract samples using physical ports of an Netduino 3 board.
        /// </summary>
        public static void Main()
        {
#if Sample01SimpleBlinker

            // Sample 01: Blink a LED:

            AbstractIO.Samples.Sample01SimpleBlinker.Run(
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue));

#elif Sample01SimpleBlinkerDistributed

            // Sample 01 again, but this time blinking several LEDs at once simply by distributing the output to them
            // using a BooleanOutputDistributor object, which on itself implements IBooleanOutput and simply passes the
            // Values to an arbitrary number of outputs:

            AbstractIO.Samples.Sample01SimpleBlinker.Run(
                lamp: new BooleanOutputDistributor(
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue),
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.GoPort1Led),
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.GoPort2Led),
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.GoPort3Led)));

#elif Sample01SimpleBlinkerAlternating

            // Sample 01 again, but this time blinking two LEDs alternating by using the BooleanOutputDistributor
            // combined with inverting one of the outputs using the BooleanOutputInverter, coded using the fluent API
            // that the corresponding extension method offers:

            AbstractIO.Samples.Sample01SimpleBlinker.Run(
                lamp: new BooleanOutputDistributor(
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.GoPort1Led),
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.GoPort2Led).Invert(),
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.GoPort3Led),
                    new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue).Invert()));

#elif Sample02ButtonControlsLampPolling

            // Sample 02: Control a LED using a button:

            AbstractIO.Samples.Sample02ButtonControlsLampPolling.Run(
                button: new Netduino3.DigitalInput(Netduino3.DigitalInputPin.OnboardButton),
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue));

#elif Sample02ButtonControlsLampPollingInvertingButton

            // Sample 02 again, but this time inverting the button simply by using a BooleanInputConverter, simply by
            // using the fluent API offered by the corresponding extension methods:

            AbstractIO.Samples.Sample02ButtonControlsLampPolling.Run(
                button: new Netduino3.DigitalInput(DigitalInputPin.OnboardButton).Invert(),
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue));

#elif Sample02ButtonControlsLampPollingInvertingLamp

            // Sample 02 again, but this time inverting the lamp simply by using a BooleanOuputConverter, simply by
            // using the fluent API offered by the corresponding extension methods:

            AbstractIO.Samples.Sample02ButtonControlsLampPolling.Run(
                button: new Netduino3.DigitalInput(DigitalInputPin.OnboardButton),
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue).Invert());

#elif Sample02ButtonControlsLampUsing2Buttons

            // Sample 02 again, but this time the lamp shall only light up if both of two buttons are pressed.
            // To use this sample, connect two closing buttons to the Netduino 3 input pins D0 and D1.

            AbstractIO.Samples.Sample02ButtonControlsLampPolling.Run(
                button: new BooleanAndInput(
                    new Netduino3.DigitalInput(Netduino3.DigitalInputPin.D0), 
                    new Netduino3.DigitalInput(Netduino3.DigitalInputPin.D1)),
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue));

#elif Sample03ButtonControlsLampEventBased

            // Sample 03: Control a lamp using a button, but this time do not poll the status of the button, but react
            // to the ValueChanged event (that is, reacting on an IRQ generated by the µC whenever the status of the
            // button's input pin changed).

            AbstractIO.Samples.Sample03ButtonControlsLampEventBased.Run(
                button: new Netduino3.ObservableDigitalInput(DigitalInputPin.OnboardButton),
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue));

#elif Sample03ButtonControlsLampEventBasedInvertingButton

            // Sample 03 again: Control a lamp using a button using events, but with an inverted button using the
            // ObserverableBooleanInputInverter class, coded using the fluent API that the extension methods offer.

            AbstractIO.Samples.Sample03ButtonControlsLampEventBased.Run(
                button: new Netduino3.ObservableDigitalInput(DigitalInputPin.OnboardButton).Invert(),
                lamp: new Netduino3.DigitalOutput(Netduino3.DigitalOutputPin.OnboardLedBlue));

#elif Sample04SmoothPwmBlinker

            // Sample 04: Let a lamp blink smoothly. The abstract code just expects any IDoubleOutput and will cyle that
            // in small steps from 0.0 to 1.0 and back to 0.0 forever. As an example of an IDoubleOutput, we pass a
            // PWM-controlled pin:

            AbstractIO.Samples.Sample04SmoothBlinker.Run(
                lamp: new Netduino3.PwmOutput(DigitalPwmOutputPin.OnboardLedBlue));

#else
#error Please uncomment exactly one of the samples.
#endif
        }
    }
}
