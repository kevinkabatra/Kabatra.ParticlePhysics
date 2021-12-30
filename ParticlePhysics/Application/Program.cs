namespace Application
{
    using System;
    using SubatomicParticles.DataModels;
    using Universe.DataModels;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this simple particle physics simulator.");
            Console.WriteLine("Developed by: Kevin Kabatra");
            Console.WriteLine("Let's get started.");
            WaitUserToContinue();

            var universe = Universe.GetOrCreateInstance();
            Console.WriteLine("At the creation of space and time there was a big bang, this gave birth to our universe.");
            PrintUniverseSubAtomicParticleCount(universe);
            Console.WriteLine("Our universe is currently empty, so let's add some particles to it.");
            WaitUserToContinue();

            Console.WriteLine("First we will add a single Neutron.");
            _ = new Neutron();
            PrintUniverseSubAtomicParticleCount(universe);
            PrintUniverseContents(universe);
            Console.WriteLine("There. That is better. Our lonely universe now has a friend it can make.");
            Console.WriteLine("Sadly this friendship cannot last long. As a neutron that is outside of a nucleus will decay in roughly 14 minutes.");
            Console.WriteLine("I wonder what it will decay to, after all the Law of Conservation of Mass says that matter cannot be destroyed. Come back once it is complete to find out.");
            WaitUserToContinue();

            // Adding some buffer for the event to finish.
            var neutronDecayTime = Neutron.ConstantBetaDecayTimeInSeconds + 1;
            var currentTime = DateTime.Now;
            // I know that I could wait with Sleep, but then I couldn't update the UI nicely to tell you how much longer to wait.
            var finishWaitTime = currentTime.AddSeconds(neutronDecayTime);
            while (currentTime < finishWaitTime)
            {
                Console.WriteLine("Waiting... Time remaining:" + (finishWaitTime - currentTime));

                // Sleeping just so that I don't print a quintillion lines to the display.
                System.Threading.Thread.Sleep(1000);
                currentTime = DateTime.Now;
            }
            Console.WriteLine();

            Console.WriteLine("What a long wait that was. Let's check on the universe to see what it contains now.");
            PrintUniverseSubAtomicParticleCount(universe);
            PrintUniverseContents(universe);
            Console.WriteLine("Wow. We now have a Proton and an Electron. Do you know what we can build with this?");
            Console.WriteLine("Hydrogen.");
            Console.WriteLine("To be continued...");
        }

        private static void PrintUniverseSubAtomicParticleCount(Universe universe)
        {
            Console.WriteLine("Universe subatomic particle count: " + universe.SubatomicParticles.Count);
        }

        private static void PrintUniverseContents(Universe universe)
        {
            Console.WriteLine("The universe currently contains:");
            foreach (var subatomicParticle in universe.SubatomicParticles)
            {
                Console.WriteLine(subatomicParticle.ToString());
            }
        }

        private static void WaitUserToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();

            const bool hideUserInput = true;
            Console.ReadKey(hideUserInput);
        }
    }
}
