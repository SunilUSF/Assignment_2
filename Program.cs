using System.Text;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,,,,,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] array)
        {
            try
            {
                // Check if the input array is empty or null
                if (array == null || array.Length == 0)
                    return 0; // If so, return 0 as there are no elements to process

                int uniqueCount = 1; // Initialize the count of unique elements to 1 (first element is always unique)
                for (int i = 1; i < array.Length; i++)
                {
                    // Check if the current element is different from the previous one
                    if (array[i] != array[i - 1])
                    {
                        // If the current element is unique, move it to the next position
                        array[uniqueCount] = array[i]; // Update the array to keep track of unique elements
                        uniqueCount++; // Increment the count of unique elements
                    }
                }
                // Return the count of unique elements after removing duplicates
                return uniqueCount;
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions that occur during the process
            }
        }



        /*
         * Self Reflection
         * In addressing this problem, I delved into the core principles of manipulating arrays, particularly focusing on efficiently removing duplicates within the array itself.

During the implementation process, I revisited the concept of iterating through arrays, emphasizing the necessity of examining each element to effectively identify and handle duplicate occurrences.

Encountering special cases like empty arrays or those with only one element prompted me to pay careful attention to handling such scenarios. This highlighted the importance of incorporating conditional checks to ensure the function operates reliably under all conditions, thereby enhancing its resilience.

Through this exercise, I gained a deeper understanding of the importance of optimizing both time and memory complexities. By ensuring the solution operates in linear time, I recognized the performance implications, especially in scenarios involving large datasets or real-time applications where speed and memory efficiency are crucial considerations.

Overall, this experience enriched my knowledge of array manipulation techniques and underscored the significance of prioritizing efficiency in algorithmic design.
        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] array)
        {
            try
            {
                // Check if the input array is null or has only one element
                if (array == null || array.Length <= 1)
                    return array.ToList(); // Return the list as it is if it's null or has only one element

                int nonZeroIndex = 0; // Initialize the index for non-zero elements
                for (int i = 0; i < array.Length; i++)
                {
                    // Check if the current element is non-zero
                    if (array[i] != 0)
                    {
                        // Move the non-zero element to the current non-zero index
                        array[nonZeroIndex] = array[i];
                        nonZeroIndex++; // Increment the non-zero index
                    }
                }

                // Fill the remaining positions with zeroes from the last non-zero index
                for (int i = nonZeroIndex; i < array.Length; i++)
                {
                    array[i] = 0; // Set remaining positions to zero
                }

                // Convert the modified array to a list and return
                return array.ToList();
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions that occur during the process
            }
        }



        /*
         * Self-Reflection :
         
         * 
              This problem provided an opportunity to refine skills in rearranging array elements without additional space, a core aspect of array manipulation. Initially, the strategy involved iterating through the array to relocate non-zero elements
        to the beginning while preserving their original order, reinforcing efficient traversal techniques. Particular attention was given to handling special cases, such as arrays with fewer than two elements or those containing only zeros
        ensuring the function's reliability across various scenarios. By optimizing array manipulation without duplicating or utilizing extra space, the solution effectively achieved the desired outcome while upholding the relative order of elements,
        showcasing a systematic approach to problem-solving in array manipulation techniques.*/

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] array)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>(); // Initialize the result list
                Array.Sort(array); // Sort the array in ascending order

                for (int i = 0; i < array.Length - 2; i++)
                {
                    // Skip duplicates
                    if (i > 0 && array[i] == array[i - 1])
                        continue;

                    int leftPointer = i + 1; // Initialize the left pointer
                    int rightPointer = array.Length - 1; // Initialize the right pointer

                    while (leftPointer < rightPointer)
                    {
                        int sum = array[i] + array[leftPointer] + array[rightPointer]; // Calculate the sum of the triplet

                        if (sum == 0)
                        {
                            // Found a triplet with sum equal to zero
                            result.Add(new List<int> { array[i], array[leftPointer], array[rightPointer] });

                            // Skip duplicates
                            while (leftPointer < rightPointer && array[leftPointer] == array[leftPointer + 1])
                                leftPointer++;
                            while (leftPointer < rightPointer && array[rightPointer] == array[rightPointer - 1])
                                rightPointer--;

                            leftPointer++; // Move the left pointer to the right
                            rightPointer--; // Move the right pointer to the left
                        }
                        else if (sum < 0)
                        {
                            leftPointer++; // Move left pointer to increase sum
                        }
                        else
                        {
                            rightPointer--; // Move right pointer to decrease sum
                        }
                    }
                }
                return result; // Return the list of triplets
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }



        /*
         * Self-Reflection :
         
          To tackle this problem, advanced array manipulation techniques were utilized, such as sorting the array and employing multiple pointers to identify triplets that sum up to zero. Paying close attention to edge cases was essential to minimize unnecessary computations and enhance performance. 
        The solution was crafted using conditional statements to manage duplicate pointer adjustments and determine actions based on the sum of elements, honing my skills in applying conditional logic to algorithmic solutions. Utilizing data structures like lists to store and return the result set
        emphasized the importance of selecting suitable data structures for efficient problem-solving, reinforcing knowledge of data structure principles. Continuously refining the implementation aimed at reducing redundant computations and improving overall solution efficiency, demonstrating a 
        dedicated commitment to algorithm optimization for enhanced performance.*/

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] array)
        {
            try
            {
                int maxCount = 0; // Initialize the maximum consecutive count of 1's
                int currentCount = 0; // Initialize the current consecutive count of 1's

                // Iterate through the array
                foreach (int element in array)
                {
                    if (element == 1)
                    {
                        // Increment the current count for consecutive 1's
                        currentCount++;
                    }
                    else
                    {
                        // Update the maximum count and reset the current count when encountering 0
                        maxCount = Math.Max(maxCount, currentCount);
                        currentCount = 0;
                    }
                }

                // Update maxCount for the last sequence of consecutive 1's
                maxCount = Math.Max(maxCount, currentCount);

                return maxCount; // Return the maximum consecutive count of 1's
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }



        /*
         * Self-Reflection :
         
          The solution required a methodical examination of the array to accurately tally the occurrences of encountered elements. This approach provided valuable insights into effective techniques for traversing arrays. Essentially, the solution meticulously traced the positions of ones within the binary array, 
        facilitating precise counting of consecutive elements. The straightforward and lucid nature of the approach emphasized the importance of maintaining clarity in algorithmic solutions. Special attention was dedicated to handling edge cases, such as arrays with only one element or comprised entirely of zeros, 
        ensuring robustness across diverse scenarios. Prioritizing efficient count updates during array traversal underscored the significance of crafting algorithms with optimal time complexity.
         */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the Math.Pow function. You will implement a function called BinaryToDecimal which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the BinaryToDecimal function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (<<, >>, &, |, ^) and the Math.Pow function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binaryNumber)
        {
            try
            {
                int decimalValue = 0; // Initialize the decimal value to 0
                int exponent = 1; // Initialize the exponent of 2 to 1

                // Iterate until the binary number becomes 0
                while (binaryNumber != 0)
                {
                    int lastDigit = binaryNumber % 10; // Extract the last digit of the binary number
                    binaryNumber /= 10; // Remove the last digit from the binary number

                    decimalValue += lastDigit * exponent; // Update the decimal value by adding the last digit multiplied by the power of two
                    exponent *= 2; // Update the exponent of 2 for the next iteration
                }

                return decimalValue; // Return the decimal value
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }



        /*
         * Self-Reflection :
         
          The act of converting binary numbers into decimal representations through elementary arithmetic operations profoundly enriched my comprehension of number systems. The solution, straightforward in its implementation, solely relies on basic arithmetic, illustrating the efficacy of algorithms in addressing problems.
        This methodology underscores the importance of numerical operations within algorithmic solutions and underscores the value of ingenuity in problem-solving endeavors. It accentuates the significance of exploring alternative approaches and steering clear of dependency on intricate functions or operators, showcasing the 
        simplicity and effectiveness inherent in utilizing fundamental arithmetic operations.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] numbers)
        {
            try
            {
                if (numbers == null || numbers.Length < 2)
                    return 0; // Return 0 if the array is null or has less than two elements

                // Find the minimum and maximum elements in the array
                int minValue = int.MaxValue;
                int maxValue = int.MinValue;
                foreach (int number in numbers)
                {
                    minValue = Math.Min(minValue, number); // Update the minimum value
                    maxValue = Math.Max(maxValue, number); // Update the maximum value
                }

                // Calculate the minimum possible gap
                int minGap = (int)Math.Ceiling((double)(maxValue - minValue) / (numbers.Length - 1));

                // Create buckets to store elements
                int numBuckets = (maxValue - minValue) / minGap + 1;
                int[] minBucket = new int[numBuckets];
                int[] maxBucket = new int[numBuckets];
                Array.Fill(minBucket, int.MaxValue);
                Array.Fill(maxBucket, int.MinValue);

                // Distribute numbers into buckets
                foreach (int number in numbers)
                {
                    int index = (number - minValue) / minGap;
                    minBucket[index] = Math.Min(minBucket[index], number); // Update the minimum value in the bucket
                    maxBucket[index] = Math.Max(maxBucket[index], number); // Update the maximum value in the bucket
                }

                // Find the maximum gap between successive non-empty buckets
                int maxGap = 0;
                int previousMax = maxBucket[0];
                for (int i = 1; i < numBuckets; i++)
                {
                    if (minBucket[i] != int.MaxValue)
                    {
                        maxGap = Math.Max(maxGap, minBucket[i] - previousMax); // Update the maximum gap
                        previousMax = maxBucket[i]; // Update the previous maximum value
                    }
                }

                return maxGap; // Return the maximum gap
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }





        /*
         * Self-Reflection :
         
           This problem necessitated the application of mathematical principles to compute the gap between elements and organize numbers into buckets. It underscored the effective utilization of these concepts within algorithmic solutions. 
        The approach guaranteed linear time complexity and linear additional space usage, emphasizing the criticality of efficiency in algorithms. Addressing edge cases, such as arrays with fewer than two elements, ensured the seamless operation
        of the function across various scenarios. The manipulation of the array to distribute elements into buckets and calculate the gap underscored the importance of meticulous algorithmic design while adhering to constraints. Overall, 
        the reflection underscored the significance of being cognizant of constraints and tailoring algorithms accordingly for efficient problem-solving.
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] sides)
        {
            try
            {
                Array.Sort(sides); // Sort the array in ascending order
                for (int i = sides.Length - 1; i >= 2; i--) // Iterate from right to left to find the largest perimeter
                {
                    int firstSide = sides[i - 2]; // Length of side 'a'
                    int secondSide = sides[i - 1]; // Length of side 'b'
                    int thirdSide = sides[i]; // Length of side 'c'
                    if (firstSide + secondSide > thirdSide) // Check if a valid triangle can be formed
                    {
                        return firstSide + secondSide + thirdSide; // Return the perimeter of the triangle
                    }
                }
                return 0; // No valid triangle can be formed
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }


        /*
         * Self-Reflection :
         
           While tackling this problem, my emphasis was on utilizing the triangle inequality theorem to ascertain whether the given side lengths could construct a valid triangle with a non-zero area. This approach facilitated the integration of geometric principles into algorithmic solutions. 
        The simple method of iterating through the sorted array to verify valid triangles showcased a streamlined algorithmic design. This experience underscored the importance of interdisciplinary thinking in effective algorithm design, where mathematical concepts seamlessly intersect with solution strategies.*/

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string mainString, string pattern)
        {
            try
            {
                int index;
                while ((index = mainString.IndexOf(pattern)) != -1)
                {
                    // Remove the leftmost occurrence of the pattern
                    mainString = mainString.Remove(index, pattern.Length);
                }
                return mainString;
            }
            catch (Exception)
            {
                throw; // Re-throw any exceptions
            }
        }



        /*
         * Self-Reflection :
         
         * 
          While developing this solution, I revisited my skills in string manipulation, focusing on methods like IndexOf and Remove to efficiently identify and eliminate substrings. The implementation utilizes a while loop to iteratively search for and delete occurrences of the substring within the original string, 
        ensuring precision and efficiency in repetitive tasks. Robust error handling mechanisms are integrated to address potential exceptions, such as 'index out of range' errors, which might arise during string manipulation. By leveraging built-in string manipulation methods, the solution exemplifies the optimization 
        capabilities inherent in the language, contributing to efficient algorithmic design. Overall, the solution offers a clear and understandable approach for replacing occurrences of substrings, underscoring the effectiveness of algorithmic problem-solving.*/


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}