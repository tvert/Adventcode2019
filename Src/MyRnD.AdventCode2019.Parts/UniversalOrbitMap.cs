using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyRnD.AdventCode2019.Parts
{

    public sealed class SpaceObject
    {
        public const string SantaName = "SAN";
        public const string YouName = "YOU";

        public SpaceObject(string name)
        : this(name, null, new List<SpaceObject>())
        {
        }

        public SpaceObject(string name, SpaceObject orbit)
            : this(name, null, new List<SpaceObject>())
        {
        }

        private SpaceObject(string name, SpaceObject orbit, List<SpaceObject> satellites)
        {
            Name = name;
            Orbit = orbit;
            Satellites = satellites;
        }

        public string Name { get; }

        /// <summary>
        /// Orbit (aka Parent).
        /// </summary>
        public SpaceObject Orbit { get; private set; }

        /// <summary>
        /// Satellite(s) (aka children).
        /// </summary>
        public List<SpaceObject> Satellites { get; }

        /// <summary>
        /// Is this the 'Universe Center of Mass' (COM)? (aka Root)
        /// </summary>
        public bool IsCOM => Orbit == null;

        /// <summary>
        /// Is this the last entry? (aka without any children)
        /// </summary>
        public bool IsLeave => !Satellites.Any();

        /// <summary>
        /// Is this 'SANTA' space object?
        /// </summary>
        public bool IsSanta => string.Equals(Name, SantaName);

        /// <summary>
        /// Is this 'YOU' space object?
        /// </summary>
        public bool IsYou => string.Equals(Name, YouName);

        public bool HasDirectSatellite(SpaceObject satellite)
        {
            var currentSatelliteObject = Satellites.Find(so => string.Equals(so.Name, satellite.Name, StringComparison.OrdinalIgnoreCase));
            return (currentSatelliteObject != null) ;
        }

        public void UpdateOrbit(SpaceObject newOrbit)
        {
            if (Orbit == null)
                Orbit = newOrbit;
            else
                throw new InvalidOperationException($"This space object is already in orbit around '{Orbit.Name}'. Cannot change it to '{newOrbit.Name}'.");
        }

        public void UpdateSatellite(SpaceObject newSatellite)
        {
            var currentSatelliteObject = Satellites.Find(so => string.Equals(so.Name, newSatellite.Name, StringComparison.OrdinalIgnoreCase));
            if (currentSatelliteObject == null)
            {
                Satellites.Add(newSatellite);
                newSatellite.UpdateOrbit(this);
            }
        }

        public override string ToString()
        {
            string s = $"{Name}";
            return s;
        }

    }


    public sealed class UniversalOrbitMap
    {
        public UniversalOrbitMap()
        {
            Objects = new List<SpaceObject>();
        }

        public List<SpaceObject> Objects { get; }

        public int NumberOfOrbits {
            get
            {
                var com = Objects.Find(so => so.IsCOM);
                if (com == null)
                    throw new InvalidOperationException("COM is not defined in this map.");

                int n = CalculateNumberOfOrbits(com, 0);
                return n;
            }
        }

        public (bool hasB, int minimumOrbitalTransfer) MinimumOrbitalTransfer(string nameA, string nameB)
        {
            var currentA = Objects.Find(so => string.Equals(so.Name, nameA, StringComparison.OrdinalIgnoreCase));
            var currentB = Objects.Find(so => string.Equals(so.Name, nameB, StringComparison.OrdinalIgnoreCase));

            List<string> exceptSatellites = new List<string> { nameA };
            (bool hasB, int minimumOrbitalTransfer) = CalculateMinimumOrbitalTransfer(currentA.Orbit, currentB, 0, exceptSatellites);
            return (hasB, minimumOrbitalTransfer);
        }

        private (bool hasB, int minimumOrbitalTransfer) CalculateMinimumOrbitalTransfer(SpaceObject newOrbit, SpaceObject currentB, int currentOrbits, List<string> exceptSatellites)
        {
            exceptSatellites.Add(newOrbit.Name);

            if (newOrbit.HasDirectSatellite(currentB))
                return (true, currentOrbits);

            foreach (var satellite in newOrbit.Satellites)
            {
                if (exceptSatellites.Contains(satellite.Name))
                    continue;

                int orbits = currentOrbits;
                (bool hasB, int minimumOrbitalTransfer) = CalculateMinimumOrbitalTransfer(satellite, currentB, ++orbits, exceptSatellites);
                if (hasB)
                {
                    return (true, minimumOrbitalTransfer);
                }
            }

            if (!newOrbit.IsCOM && !exceptSatellites.Contains(newOrbit.Orbit.Name))
            {
                (bool hasBFromParent, int minimumOrbitalTransferFromParent) =
                    CalculateMinimumOrbitalTransfer(newOrbit.Orbit, currentB, ++currentOrbits, exceptSatellites);
                if (hasBFromParent)
                {
                    return (true, minimumOrbitalTransferFromParent);
                }
            }

            return (false, currentOrbits);
        }

        private int CalculateNumberOfOrbits(SpaceObject so, int currentOrbits)
        {
            if (!so.IsCOM)
                currentOrbits++;

            if (so.IsLeave)
                return currentOrbits;

            int satelliteOrbits = 0;
            foreach (var satellite in so.Satellites)
            {
                satelliteOrbits += CalculateNumberOfOrbits(satellite, currentOrbits);
            }

            int total = currentOrbits + satelliteOrbits;
            return total;
        }


        public void AddAndUpdateOrbit(SpaceObject newOrbit, SpaceObject newSatellite)
        {
            var currentOrbitObject = Objects.Find(so => string.Equals(so.Name, newOrbit.Name, StringComparison.OrdinalIgnoreCase));
            var currentSatelliteObject = Objects.Find(so => string.Equals(so.Name, newSatellite.Name, StringComparison.OrdinalIgnoreCase));
            if (currentOrbitObject != null)
            {
                currentOrbitObject.UpdateSatellite(currentSatelliteObject ?? newSatellite);
            }
            else
            {
                newOrbit.UpdateSatellite(currentSatelliteObject ?? newSatellite);
                Objects.Add(newOrbit);
            }

            // Add satellite if it does not exist already.
            if (currentSatelliteObject == null)
                Objects.Add(newSatellite);
        }

        public void UpdateFromString(string map)
        {
            using (var sr = new StringReader(map))
            {
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 1 orbit relation per line
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            UpdateFromLine(line);
                        }
                    }
                }

            }
        }

        public void UpdateFromLine(string line)
        {
            var objectsTextInLine = line.Split(')');
            if (objectsTextInLine.Length == 2)
            {
                var orbitObject = new SpaceObject(objectsTextInLine[0]);
                var satelliteObject = new SpaceObject(objectsTextInLine[1]);
                AddAndUpdateOrbit(orbitObject, satelliteObject);
            }
            else
            {
                throw new InvalidOperationException($"Incomplete line '{line}' - should have 2 space objects delimited by ')'.");
            }
        }
    }
}