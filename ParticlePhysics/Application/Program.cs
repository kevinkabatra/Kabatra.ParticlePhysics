namespace Application
{
    using System;
    using System.Linq;
    using Universe.SubatomicParticles.DataModels.CompositeParticles.Hadrons.Baryons;
    using Universe.SubatomicParticles.DataModels.ElementaryParticles;
    using Universe.SubatomicParticles.DataModels.ElementaryParticles.Quarks;
    using Universe.SubatomicParticles.Interfaces;
    using Universe.SubatomicParticles.Interfaces.ElementaryParticles;
    using Universe.SubatomicParticles.Interfaces.ElementaryParticles.Quarks;
    using Universe.Universe.Constants;
    using Universe.Universe.DataModels;
    using Universe.Universe.Utilities;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this simple particle physics simulator.");
            Console.WriteLine("Developed by: Kevin Kabatra");
            Console.WriteLine("Let's get started.");
            WaitUserToContinue();

            var universe = (Universe) UniverseUtility<Universe>.GetOrCreateUniverse();
            Console.WriteLine("At the creation of space and time there was an invisible explosion, we call this the big bang.");
            Console.WriteLine("The Big Bang was invisible because until the Recombination Epoch all of the Photons would have bounced off of free Nucleons and Electrons, thus scattering all of the visible light.");
            Console.WriteLine("Our current Standard Model of Cosmology cannot predict what happened at 0 seconds, because our theories breakdown at this scale.");
            Console.WriteLine("But we can start to predict and model what happens starting at the Planck epoch at 10 -43 seconds.");
            Console.WriteLine("During this time cosmology and physics are assumed to have been dominated by the quantum effects of gravity.");
            Console.WriteLine("Lets take a look at our universe");
            PrintUniverseProperties(universe);
            PrintUniverseSubAtomicParticleCount(universe);
            Console.WriteLine("Our universe is hot and empty. We will need to proceed further in time in order to see particles appear.");
            WaitUserToContinue();

            universe.SetEpoch(Epoch.BeginningQuarkEpoch);
            PrintUniverseProperties(universe);
            Console.WriteLine("Welcome to the beginning of the Quark epoch. Here we will be able to witness the formation of Quark Gluon plasma.");
            _ = new UpQuark();
            _ = new DownQuark();
            _ = new DownQuark();
            _ = new Gluon();
            _ = new Gluon();
            PrintUniverseContents(universe);
            Console.WriteLine("Normally Quarks and Gluons would bind together but it is currently too hot for them to do so, the heat gives them so much energy that they can resist the Strong Nuclear Force.");
            PrintUniverseAttachedParticles(universe);
            Console.WriteLine("Is that number zero? It should be zero, if it is not, well then the Standard Model of Cosmology has failed us.");
            WaitUserToContinue();

            Console.WriteLine("Take a look at the list of particles that were created. Do you recognize what those can build?");
            Console.WriteLine("Well each Gluon can bind to two Quarks. Three Quarks bound together in such a way will form a Hadron.");
            Console.WriteLine("Hadrons are composite particles like Neutrons and Protons.");
            Console.WriteLine("And the recipe for a Neutron is one Up Quark and two Down Quarks.");
            Console.WriteLine("We just need a little more time in order to have the Quarks and Gluons bind together.");
            WaitUserToContinue();

            universe.SetEpoch(Epoch.EndQuarkEpoch);
            WaitForSeconds(2);
            PrintUniverseSubAtomicParticleCount(universe);
            PrintUniverseAttachedParticles(universe);
            Console.WriteLine("Now all of our particles should be attached. This means that we have formed a Hadron. Let's take a look at our single Neutron.");
            WaitUserToContinue();

            var quarks = universe.SubatomicParticles.OfType<IQuark>().ToList();
            var gluons = universe.SubatomicParticles.OfType<IGluon>().ToList();
            _ = new Neutron(quarks, gluons);
            PrintUniverseSubAtomicParticleCount(universe);
            PrintUniverseContents(universe);
            Console.WriteLine("Look at that, what an accomplishment!");
            Console.WriteLine("Sadly this cannot last long. As a neutron that is outside of a nucleus will decay in roughly 14 minutes.");
            Console.WriteLine("I wonder what it will decay to, after all the Law of Conservation of Mass says that matter cannot be destroyed. Come back once it is complete to find out.");
            WaitUserToContinue();

            // Adding some buffer for the event to finish.
            var neutronDecayTime = Neutron.ConstantBetaDecayTimeInSeconds + 1;
            WaitForSeconds(neutronDecayTime);

            Console.WriteLine("What a long wait that was. Let's check on the universe to see what it contains now.");
            PrintUniverseSubAtomicParticleCount(universe);
            PrintUniverseContents(universe);
            Console.WriteLine("Wow. We now have a Proton and an Electron. Do you know what we can build with this?");
            Console.WriteLine("Hydrogen.");
            Console.WriteLine("To be continued...");
        }

        private static void WaitForSeconds(int numberOfSecondsToWait)
        {
            var currentTime = DateTime.Now;
            // I know that I could wait with Sleep, but then I couldn't update the UI nicely to tell you how much longer to wait.
            var finishWaitTime = currentTime.AddSeconds(numberOfSecondsToWait);
            while (currentTime < finishWaitTime)
            {
                Console.WriteLine("Waiting... Time remaining:" + (finishWaitTime - currentTime));

                // Sleeping just so that I don't print a quintillion lines to the display.
                System.Threading.Thread.Sleep(1000);
                currentTime = DateTime.Now;
            }
            Console.WriteLine();
        }

        private static void PrintUniverseAttachedParticles(Universe universe)
        {
            Console.WriteLine($"Number of attached particles = {universe.SubatomicParticles.OfType<ISubatomicParticle>().Count(subatomicParticle => subatomicParticle.HasAttractedToAnotherObject)}.");
        }

        private static void PrintUniverseSubAtomicParticleCount(Universe universe)
        {
            Console.WriteLine("Universe subatomic particle count: " + universe.SubatomicParticles.Count);
        }

        private static void PrintUniverseContents(Universe universe)
        {
            Console.WriteLine("The universe currently contains:");
            
            var iterator = 1;
            foreach (var subatomicParticle in universe.SubatomicParticles)
            {
                Console.WriteLine("    " + iterator + ": " + subatomicParticle.GetType().Name);
                iterator++;
            }
        }

        private static void PrintUniverseProperties(Universe universe)
        {
            Console.WriteLine($"We are currently in the {universe.Epoch}, the time is currently {universe.TimeInSeconds} seconds, and the temperature is {universe.TemperatureInKelvin} Kelvin.");
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
