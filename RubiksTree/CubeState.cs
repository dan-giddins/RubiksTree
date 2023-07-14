using System.Linq;

namespace RubiksTree;
internal class CubeState
{
	// front, right, back, left, top, bottom
	private readonly FaceColour[,,] Faces;
	private CubeState? TurnBottomLeft;
	private CubeState? TurnBottomRight;
	private CubeState? TurnRightForward;
	private CubeState? TurnRightBack;
	private CubeState? TurnBackLeft;
	private CubeState? TurnBackRight;
	private readonly IList<CubeState> AllCubeStates;

	public CubeState(FaceColour[,,] faces, IList<CubeState> allCubeStates)
	{
		Faces = faces;
		AllCubeStates = allCubeStates;
	}

	private FaceColour[,,] DeepCopyFaces()
	{
		var result = new FaceColour[Faces.GetLength(0), Faces.GetLength(1), Faces.GetLength(2)];
		Array.Copy(Faces, result, Faces.Length);
		return result;
	}

	public void GenAllTurns()
	{
		var turnBottomLeftFaces = DeepCopyFaces();
		turnBottomLeftFaces[0, 1, 0] = Faces[1, 1, 0];
		turnBottomLeftFaces[0, 1, 1] = Faces[1, 1, 1];
		turnBottomLeftFaces[1, 1, 0] = Faces[2, 1, 0];
		turnBottomLeftFaces[1, 1, 1] = Faces[2, 1, 1];
		turnBottomLeftFaces[2, 1, 0] = Faces[3, 1, 0];
		turnBottomLeftFaces[2, 1, 1] = Faces[3, 1, 1];
		turnBottomLeftFaces[3, 1, 0] = Faces[0, 1, 0];
		turnBottomLeftFaces[3, 1, 1] = Faces[0, 1, 1];
		turnBottomLeftFaces[5, 0, 0] = Faces[5, 0, 1];
		turnBottomLeftFaces[5, 0, 1] = Faces[5, 1, 1];
		turnBottomLeftFaces[5, 1, 0] = Faces[5, 0, 0];
		turnBottomLeftFaces[5, 1, 1] = Faces[5, 1, 0];
		var turnBottomLeftCubeState = new CubeState(turnBottomLeftFaces, AllCubeStates);
		AllCubeStates.Add(turnBottomLeftCubeState);
		TurnBottomLeft = turnBottomLeftCubeState;
		turnBottomLeftCubeState.GenAllTurns();

		var turnBottomRightFaces = DeepCopyFaces();
		turnBottomRightFaces[0, 1, 0] = Faces[3, 1, 0];
		turnBottomRightFaces[0, 1, 1] = Faces[3, 1, 1];
		turnBottomRightFaces[1, 1, 0] = Faces[0, 1, 0];
		turnBottomRightFaces[1, 1, 1] = Faces[0, 1, 1];
		turnBottomRightFaces[2, 1, 0] = Faces[1, 1, 0];
		turnBottomRightFaces[2, 1, 1] = Faces[1, 1, 1];
		turnBottomRightFaces[3, 1, 0] = Faces[2, 1, 0];
		turnBottomRightFaces[3, 1, 1] = Faces[2, 1, 1];
		turnBottomRightFaces[5, 0, 0] = Faces[5, 1, 0];
		turnBottomRightFaces[5, 0, 1] = Faces[5, 0, 0];
		turnBottomRightFaces[5, 1, 0] = Faces[5, 1, 1];
		turnBottomRightFaces[5, 1, 1] = Faces[5, 0, 1];
		var turnBottomRightCubeState = new CubeState(turnBottomRightFaces, AllCubeStates);
		AllCubeStates.Add(turnBottomRightCubeState);
		TurnBottomRight = turnBottomRightCubeState;
		turnBottomRightCubeState.GenAllTurns();

		var turnRightFowardFaces = DeepCopyFaces();
		turnRightFowardFaces[0, 0, 1] = Faces[4, 0, 1];
		turnRightFowardFaces[0, 1, 1] = Faces[4, 1, 1];
		turnRightFowardFaces[4, 0, 1] = Faces[2, 0, 1];
		turnRightFowardFaces[4, 1, 1] = Faces[2, 1, 1];
		turnRightFowardFaces[2, 0, 1] = Faces[5, 0, 1];
		turnRightFowardFaces[2, 1, 1] = Faces[5, 1, 1];
		turnRightFowardFaces[5, 0, 1] = Faces[0, 0, 1];
		turnRightFowardFaces[5, 1, 1] = Faces[0, 1, 1];
		turnRightFowardFaces[2, 0, 0] = Faces[2, 0, 1];
		turnRightFowardFaces[2, 0, 1] = Faces[2, 1, 1];
		turnRightFowardFaces[2, 1, 0] = Faces[2, 0, 0];
		turnRightFowardFaces[2, 1, 1] = Faces[2, 1, 0];
		var turnRightFowardCubeState = new CubeState(turnRightFowardFaces, AllCubeStates);
		AllCubeStates.Add(turnRightFowardCubeState);
		TurnRightForward = turnRightFowardCubeState;
		turnRightFowardCubeState.GenAllTurns();

		var turnRightBackFaces = DeepCopyFaces();
		turnRightBackFaces[0, 0, 1] = Faces[5, 0, 1];
		turnRightBackFaces[0, 1, 1] = Faces[5, 1, 1];
		turnRightBackFaces[4, 0, 1] = Faces[0, 0, 1];
		turnRightBackFaces[4, 1, 1] = Faces[0, 1, 1];
		turnRightBackFaces[2, 0, 1] = Faces[4, 0, 1];
		turnRightBackFaces[2, 1, 1] = Faces[4, 1, 1];
		turnRightBackFaces[5, 0, 1] = Faces[2, 0, 1];
		turnRightBackFaces[5, 1, 1] = Faces[2, 1, 1];
		turnRightBackFaces[2, 0, 0] = Faces[2, 1, 0];
		turnRightBackFaces[2, 0, 1] = Faces[2, 0, 0];
		turnRightBackFaces[2, 1, 0] = Faces[2, 1, 1];
		turnRightBackFaces[2, 1, 1] = Faces[2, 0, 1];
		var turnRightBackCubeState= new CubeState(turnRightBackFaces, AllCubeStates);
		AllCubeStates.Add(turnRightBackCubeState);
		TurnRightBack = turnRightBackCubeState;
		turnRightBackCubeState.GenAllTurns();

		var turnBackLeftFaces = DeepCopyFaces();
		turnBackLeftFaces[1, 0, 1] = Faces[5, 1, 0];
		turnBackLeftFaces[1, 1, 1] = Faces[5, 1, 1];
		turnBackLeftFaces[4, 0, 0] = Faces[1, 0, 1];
		turnBackLeftFaces[4, 0, 1] = Faces[1, 1, 1];
		turnBackLeftFaces[3, 0, 0] = Faces[4, 0, 0];
		turnBackLeftFaces[3, 1, 0] = Faces[4, 0, 1];
		turnBackLeftFaces[5, 1, 0] = Faces[3, 0, 0];
		turnBackLeftFaces[5, 1, 1] = Faces[3, 1, 0];
		turnBackLeftFaces[2, 0, 0] = Faces[2, 1, 0];
		turnBackLeftFaces[2, 0, 1] = Faces[2, 0, 0];
		turnBackLeftFaces[2, 1, 0] = Faces[2, 1, 1];
		turnBackLeftFaces[2, 1, 1] = Faces[2, 0, 1];
		var turnBackLeftCubeState = new CubeState(turnBackLeftFaces, AllCubeStates);
		AllCubeStates.Add(turnBackLeftCubeState);
		TurnBackLeft = turnBackLeftCubeState;
		turnBackLeftCubeState.GenAllTurns();

		var turnBackRightFaces = DeepCopyFaces();
		turnBackRightFaces[1, 0, 1] = Faces[4, 0, 0];
		turnBackRightFaces[1, 1, 1] = Faces[4, 0, 1];
		turnBackRightFaces[4, 0, 0] = Faces[3, 0, 0];
		turnBackRightFaces[4, 0, 1] = Faces[3, 1, 0];
		turnBackRightFaces[3, 0, 0] = Faces[5, 1, 0];
		turnBackRightFaces[3, 1, 0] = Faces[5, 1, 1];
		turnBackRightFaces[5, 1, 0] = Faces[1, 0, 1];
		turnBackRightFaces[5, 1, 1] = Faces[1, 1, 1];
		turnBackRightFaces[2, 0, 0] = Faces[2, 0, 1];
		turnBackRightFaces[2, 0, 1] = Faces[2, 1, 1];
		turnBackRightFaces[2, 1, 0] = Faces[2, 0, 0];
		turnBackRightFaces[2, 1, 1] = Faces[2, 1, 0];
		var turnBackRightCubeState = new CubeState(turnBackRightFaces, AllCubeStates);
		AllCubeStates.Add(turnBackRightCubeState);
		TurnBackRight = turnBackRightCubeState;
		turnBackRightCubeState.GenAllTurns();
	}
}
