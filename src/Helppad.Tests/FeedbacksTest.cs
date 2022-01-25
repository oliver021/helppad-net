using NUnit.Framework;
using System.Threading.Tasks;

namespace Helppad.Tests
{
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            using var feed = FeedBack.CreateFeedback<int>(async push => {
                // delay
                await Task.Delay(1000);
                
                // push data
                await push(11);
                await push(12);
                await push(9);
            });

            int[] arr = new int[3];
            int i = 0;

            // loop to recive
            while (!feed.Complete.IsCompleted)
            {
                arr[i] = await feed.NextAsync();
                i++;
            }

            // push equals
            Assert.AreEqual(arr[0], 11);
            Assert.AreEqual(arr[1], 12);
            Assert.AreEqual(arr[2], 9);
        }
    }
}