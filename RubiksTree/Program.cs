using RubiksTree;
var allCubeStates = new List<CubeState>();
var baseState = new CubeState(
	new FaceColour[,,]
	{
		{
			{ FaceColour.White, FaceColour.White },
			{ FaceColour.White, FaceColour.White }
		},
		{
			{ FaceColour.Red, FaceColour.Red },
			{ FaceColour.Red, FaceColour.Red }
		},
		{
			{ FaceColour.Yellow, FaceColour.Yellow },
			{ FaceColour.Yellow, FaceColour.Yellow }
		},
		{
			{ FaceColour.Orange, FaceColour.Orange },
			{ FaceColour.Orange, FaceColour.Orange }
		},
		{
			{ FaceColour.Blue, FaceColour.Blue },
			{ FaceColour.Blue, FaceColour.Blue }
		},
		{
			{ FaceColour.Green, FaceColour.Green },
			{ FaceColour.Green, FaceColour.Green }
		}
},
	allCubeStates);
allCubeStates.Add(baseState);
baseState.GenAllTurns();
var x = 1;