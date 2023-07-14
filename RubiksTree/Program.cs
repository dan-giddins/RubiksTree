using RubiksTree;

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
});

var turnBottomLeftFaces = baseState.DeepCopyFaces();
turnBottomLeftFaces[0, 1, 0] = baseState.Faces[1, 1, 0];
turnBottomLeftFaces[0, 1, 1] = baseState.Faces[1, 1, 1];
turnBottomLeftFaces[1, 1, 0] = baseState.Faces[2, 1, 0];
turnBottomLeftFaces[1, 1, 1] = baseState.Faces[2, 1, 1];
turnBottomLeftFaces[2, 1, 0] = baseState.Faces[3, 1, 0];
turnBottomLeftFaces[2, 1, 1] = baseState.Faces[3, 1, 1];
turnBottomLeftFaces[3, 1, 0] = baseState.Faces[0, 1, 0];
turnBottomLeftFaces[3, 1, 1] = baseState.Faces[0, 1, 1];

turnBottomLeftFaces[5, 0, 0] = baseState.Faces[5, 0, 1];
turnBottomLeftFaces[5, 0, 1] = baseState.Faces[5, 1, 1];
turnBottomLeftFaces[5, 1, 0] = baseState.Faces[5, 0, 0];
turnBottomLeftFaces[5, 1, 1] = baseState.Faces[5, 1, 0];
baseState.TurnBottomLeft = new CubeState(turnBottomLeftFaces);

var turnBottomRightFaces = baseState.DeepCopyFaces();
turnBottomRightFaces[0, 1, 0] = baseState.Faces[3, 1, 0];
turnBottomRightFaces[0, 1, 1] = baseState.Faces[3, 1, 1];
turnBottomRightFaces[1, 1, 0] = baseState.Faces[0, 1, 0];
turnBottomRightFaces[1, 1, 1] = baseState.Faces[0, 1, 1];
turnBottomRightFaces[2, 1, 0] = baseState.Faces[1, 1, 0];
turnBottomRightFaces[2, 1, 1] = baseState.Faces[1, 1, 1];
turnBottomRightFaces[3, 1, 0] = baseState.Faces[2, 1, 0];
turnBottomRightFaces[3, 1, 1] = baseState.Faces[2, 1, 1];

turnBottomRightFaces[5, 0, 0] = baseState.Faces[5, 1, 0];
turnBottomRightFaces[5, 0, 1] = baseState.Faces[5, 0, 0];
turnBottomRightFaces[5, 1, 0] = baseState.Faces[5, 1, 1];
turnBottomRightFaces[5, 1, 1] = baseState.Faces[5, 0, 1];
baseState.TurnBottomRight = new CubeState(turnBottomRightFaces);

var turnRightFowardFaces = baseState.DeepCopyFaces();
turnRightFowardFaces[0, 0, 1] = baseState.Faces[4, 0, 1];
turnRightFowardFaces[0, 1, 1] = baseState.Faces[4, 1, 1];
turnRightFowardFaces[4, 0, 1] = baseState.Faces[2, 0, 1];
turnRightFowardFaces[4, 1, 1] = baseState.Faces[2, 1, 1];
turnRightFowardFaces[2, 0, 1] = baseState.Faces[5, 0, 1];
turnRightFowardFaces[2, 1, 1] = baseState.Faces[5, 1, 1];
turnRightFowardFaces[5, 0, 1] = baseState.Faces[0, 0, 1];
turnRightFowardFaces[5, 1, 1] = baseState.Faces[0, 1, 1];

turnRightFowardFaces[2, 0, 0] = baseState.Faces[2, 0, 1];
turnRightFowardFaces[2, 0, 1] = baseState.Faces[2, 1, 1];
turnRightFowardFaces[2, 1, 0] = baseState.Faces[2, 0, 0];
turnRightFowardFaces[2, 1, 1] = baseState.Faces[2, 1, 0];
baseState.TurnRightForward = new CubeState(turnRightFowardFaces);

var turnRightBackFaces = baseState.DeepCopyFaces();
turnRightBackFaces[0, 0, 1] = baseState.Faces[5, 0, 1];
turnRightBackFaces[0, 1, 1] = baseState.Faces[5, 1, 1];
turnRightBackFaces[4, 0, 1] = baseState.Faces[0, 0, 1];
turnRightBackFaces[4, 1, 1] = baseState.Faces[0, 1, 1];
turnRightBackFaces[2, 0, 1] = baseState.Faces[4, 0, 1];
turnRightBackFaces[2, 1, 1] = baseState.Faces[4, 1, 1];
turnRightBackFaces[5, 0, 1] = baseState.Faces[2, 0, 1];
turnRightBackFaces[5, 1, 1] = baseState.Faces[2, 1, 1];

turnRightBackFaces[2, 0, 0] = baseState.Faces[2, 1, 0];
turnRightBackFaces[2, 0, 1] = baseState.Faces[2, 0, 0];
turnRightBackFaces[2, 1, 0] = baseState.Faces[2, 1, 1];
turnRightBackFaces[2, 1, 1] = baseState.Faces[2, 0, 1];
baseState.TurnRightBack = new CubeState(turnRightBackFaces);

var turnBackLeftFaces = baseState.DeepCopyFaces();
turnBackLeftFaces[1, 0, 1] = baseState.Faces[5, 1, 0];
turnBackLeftFaces[1, 1, 1] = baseState.Faces[5, 1, 1];
turnBackLeftFaces[4, 0, 0] = baseState.Faces[1, 0, 1];
turnBackLeftFaces[4, 0, 1] = baseState.Faces[1, 1, 1];
turnBackLeftFaces[3, 0, 0] = baseState.Faces[4, 0, 0];
turnBackLeftFaces[3, 1, 0] = baseState.Faces[4, 0, 1];
turnBackLeftFaces[5, 1, 0] = baseState.Faces[3, 0, 0];
turnBackLeftFaces[5, 1, 1] = baseState.Faces[3, 1, 0];

turnBackLeftFaces[2, 0, 0] = baseState.Faces[2, 1, 0];
turnBackLeftFaces[2, 0, 1] = baseState.Faces[2, 0, 0];
turnBackLeftFaces[2, 1, 0] = baseState.Faces[2, 1, 1];
turnBackLeftFaces[2, 1, 1] = baseState.Faces[2, 0, 1];
baseState.TurnBackLeft = new CubeState(turnBackLeftFaces);

var turnBackRightFaces = baseState.DeepCopyFaces();
turnBackRightFaces[1, 0, 1] = baseState.Faces[4, 0, 0];
turnBackRightFaces[1, 1, 1] = baseState.Faces[4, 0, 1];
turnBackRightFaces[4, 0, 0] = baseState.Faces[3, 0, 0];
turnBackRightFaces[4, 0, 1] = baseState.Faces[3, 1, 0];
turnBackRightFaces[3, 0, 0] = baseState.Faces[5, 1, 0];
turnBackRightFaces[3, 1, 0] = baseState.Faces[5, 1, 1];
turnBackRightFaces[5, 1, 0] = baseState.Faces[1, 0, 1];
turnBackRightFaces[5, 1, 1] = baseState.Faces[1, 1, 1];

turnBackRightFaces[2, 0, 0] = baseState.Faces[2, 0, 1];
turnBackRightFaces[2, 0, 1] = baseState.Faces[2, 1, 1];
turnBackRightFaces[2, 1, 0] = baseState.Faces[2, 0, 0];
turnBackRightFaces[2, 1, 1] = baseState.Faces[2, 1, 0];
baseState.TurnBackLeft = new CubeState(turnBackLeftFaces);
