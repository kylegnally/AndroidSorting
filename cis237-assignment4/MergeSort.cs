/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

/**
 *  The {@code Merge} class provides static methods for sorting an
 *  array using mergesort.
 *  <p>
 *  For additional documentation, see <a href="https://algs4.cs.princeton.edu/22mergesort">Section 2.2</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *  For an optimized version, see {@link MergeX}.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 *
 *
 *  Modified for this purpose by Kyle Nally
 */

using System.Diagnostics;

namespace cis237_assignment4
{
    class MergeSort
    {
        private IDroid[] Droids;
        private IDroid[] aux;

        /// <summary>
        /// Reads in a sequence of strings from standard input; mergesorts them; 
        /// and prints them to standard output in ascending order.
        /// </summary>
        /// <param name="droids"></param>
        public MergeSort(IDroid[] droids)
        {
            Droids = droids;
            Sort(Droids);
        }

        /// <summary>
        /// stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="aux"></param>
        /// <param name="lo"></param>
        /// <param name="mid"></param>
        /// <param name="hi"></param>
        private static void Merge(IDroid[] a, IDroid[] aux, int lo, int mid, int hi)
        {

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }

        /// <summary>
        /// mergesort a[lo..hi] using auxiliary array aux[lo..hi]. This is called from inside the MergeSort class.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="aux"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private static void Sort(IDroid[] a, IDroid[] aux, int lo, int hi)
        {
            // this is the base case
            if (hi <= lo) return; 
                                
            // find the midpoint of the array
            int mid = lo + (hi - lo) / 2;

            // sort the "left" half
            Sort(a, aux, lo, mid);

            // sort the "right" half
            Sort(a, aux, mid + 1, hi);

            // merge them
            Merge(a, aux, lo, mid, hi);
        }

        /// <summary>
        /// Rearranges the array in ascending order, using the natural order.
        /// This method is called from the MergeSort constructor.
        /// The two Sort methods have different signatures, so the recursive call will be made
        /// to the Srt method Sort(IDroid[] a, IDroid[] aux, int lo, int hi).
        /// </summary>
        /// <param name="a"></param>
        private static void Sort(IDroid[] a)
        {
            // create an IDroid[], aux, equal in length to a[]
            IDroid[] aux = new IDroid[a.Length];

            // sort ausing auxiliary array aux, starting at zero, with the length of array a minus one
            Sort(a, aux, 0, a.Length - 1);
        }


        /***************************************************************************
         *  Helper sorting function.
         ***************************************************************************/

        /// <summary>
        /// This method does a null check on IDroid v. If v is null, it returns false.
        /// It then returns a bool based on the result of the CompareTo method in the
        /// Droid class.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns>bool</returns>
        private static bool Less(IDroid v, IDroid w)
        {
            if (v == null /*|| w == null*/) return false;
            return v.CompareTo(w) < 0;
        }
    }
}
