namespace WeaterLibrary
{
    public class SunshineMeasurement
    {
       
            private string cityName;  // The name of the city.

            private int[] sunshine;  // Amount of sunshine per day in the most recent days in this city (in minutes).
            private int n;           // The number of days the sunshine has been measured and stored in array "sunshine".

            private const int MaxSize = 10;  // Maximum number of measurements to be stored in "sunshine".

            /// <summary>
            /// Creates a new SunshineMeasurement-object with cityName nm and no measurements yet.
            /// </summary>
            /// <param name="name"></param>
            public SunshineMeasurement(string nm)
            {
                this.cityName = nm;
                this.sunshine = new int[MaxSize];
                this.n = 0;
            }

            public string CityName { get { return this.cityName; } }

            /// <summary>
            /// The name of the method is self-explanatory.
            /// </summary>
            /// <param name="minutesOfSunshine"></param>
            public void AddSunshineOfLastDay(int minutesOfSunshine)
            {
                if (this.n < this.sunshine.Length)
                {
                    // The array is not completely filled: just add it.
                    this.sunshine[this.n] = minutesOfSunshine;
                    this.n++;
                }
                else
                {
                    // The array is completely filled: throw away the oldest measurement and add the new one.
                    for (int i = 1; i < this.sunshine.Length; i++)
                    {
                        this.sunshine[i] = this.sunshine[i - 1];
                    }
                    this.sunshine[this.sunshine.Length - 1] = minutesOfSunshine;
                }
            }

            /// <summary>
            /// Returns the average amount of sunshine according to the measurements stored in the array.
            /// It throws an exception if there are no measurements.
            /// </summary>
            /// <returns></returns>
            public int GetAverageSunshine()
            {
                int sum = 0;
                for (int i = 0; i < this.sunshine.Length; i++)
                {
                    sum += this.sunshine[i];
                }

                return (sum / this.sunshine.Length);
            }

            /// <summary>
            /// Returns the maximum amount of sunshine registered in the array.
            /// It throws an exception if there are no measurements.
            /// </summary>
            /// <returns></returns>
            public int GetMaximumSunshine()
            {
                // To do
                throw new NotImplementedException();
            }
        }

    }
