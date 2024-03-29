﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class Factory
    {
        const int BufferSize = 1024;

        public UniversalOrbitMap CreateUniversalOrbitMapFromFile(string fullFileName)
        {
            var tempMap = new UniversalOrbitMap();
            using (var fileStream = File.OpenRead(fullFileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // 1 orbit relation per line
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        tempMap.UpdateFromLine(line);
                    }
                }
            }
            return tempMap;
        }

        public IInputter CreateAutoInputter(int autoValue)
        {
            return new AutoInputter(autoValue);
        }
        public IOutputter CreateConsoleOutputter()
        {
            return new ConsoleOutputter();
        }

        public PasswordEvaluator CreatePasswordEvaluator()
        {
            return new PasswordEvaluator();
        }

        public CrossedWiresResolver CreateCrossedWiresResolver()
        {
            return new CrossedWiresResolver();
        }

        public CircuitPanel CreateCircuitPanelFromFile(string fullFileName)
        {
            List<WirePath> wirePaths = new List<WirePath>();
            using (var fileStream = File.OpenRead(fullFileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // 1 wire path per line
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var wirePathTextInLine = line.Split(',');
                        var wirePath = new WirePath();
                        wirePath.AddRange(wirePathTextInLine);
                        wirePaths.Add(wirePath);
                    }
                }
            }
            var tempCircuitPanel = new CircuitPanel(wirePaths, CreateCrossedWiresResolver());
            return tempCircuitPanel;
        }

        public IntCodeComputer CreateIntCodeComputerFromFile(string fullFileName)
        {
            return CreateIntCodeComputerFromFile(fullFileName, CreateAutoInputter(0), CreateConsoleOutputter());
        }

        public IntCodeComputer CreateIntCodeComputerFromFile(
            string fullFileName, IInputter inputter, IOutputter outputter)
        {
            List<int> opCodes = new List<int>();
            using (var fileStream = File.OpenRead(fullFileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // line has only one value
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var opCodesTextInLine = line.Split(',');
                        var opCodesInLine = opCodesTextInLine.Select(int.Parse).ToList();
                        opCodes.AddRange(opCodesInLine);
                    }
                }
            }
            var tempIntCodeComputer = new IntCodeComputer(opCodes.ToList(), inputter, outputter);
            return tempIntCodeComputer;
        }
        
        public Rocket CreateRocketFromFile(string fullFileName)
        {
            var tempRocket = new Rocket();
            using (var fileStream = File.OpenRead(fullFileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // line has only one value
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        int moduleMass = int.Parse(line);
                        var tempModule = new Module { Mass = moduleMass };
                        tempRocket.Modules.Add(tempModule);
                    }
                }
            }
            return tempRocket;
        }
    }
}