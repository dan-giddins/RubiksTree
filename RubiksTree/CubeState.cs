using System.Linq;

namespace RubiksTree;
internal class CubeState
{
	// front, right, back, left, top, bottom
	private readonly FaceColour[,,] Faces;
	private CubeState? TurnBottomLeftCubeState;
	private CubeState? TurnBottomRightCubeState;
	private CubeState? TurnRightForwardCubeState;
	private CubeState? TurnRightBackCubeState;
	private CubeState? TurnBackLeftCubeState;
	private CubeState? TurnBackRightCubeState;

	public CubeState(FaceColour[,,] faces) =>
		Faces = faces;

	private FaceColour[,,] DeepCopyFaces()
	{
		var result = new FaceColour[Faces.GetLength(0), Faces.GetLength(1), Faces.GetLength(2)];
		Array.Copy(Faces, result, Faces.Length);
		return result;
	}

	public void GenAllTurns(IList<CubeState> allCubeStates, Queue<CubeState> queue)
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
		ProcessFaces(turnBottomLeftFaces, ref TurnBottomLeftCubeState, allCubeStates, queue, "TurnBottomRightCubeState");

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
		ProcessFaces(turnBottomRightFaces, ref TurnBottomRightCubeState, allCubeStates, queue);

		var turnRightForwardFaces = DeepCopyFaces();
		turnRightForwardFaces[0, 0, 1] = Faces[4, 0, 1];
		turnRightForwardFaces[0, 1, 1] = Faces[4, 1, 1];
		turnRightForwardFaces[4, 0, 1] = Faces[2, 0, 1];
		turnRightForwardFaces[4, 1, 1] = Faces[2, 1, 1];
		turnRightForwardFaces[2, 0, 1] = Faces[5, 0, 1];
		turnRightForwardFaces[2, 1, 1] = Faces[5, 1, 1];
		turnRightForwardFaces[5, 0, 1] = Faces[0, 0, 1];
		turnRightForwardFaces[5, 1, 1] = Faces[0, 1, 1];
		turnRightForwardFaces[1, 0, 0] = Faces[1, 0, 1];
		turnRightForwardFaces[1, 0, 1] = Faces[1, 1, 1];
		turnRightForwardFaces[1, 1, 0] = Faces[1, 0, 0];
		turnRightForwardFaces[1, 1, 1] = Faces[1, 1, 0];
		ProcessFaces(turnRightForwardFaces, ref TurnRightForwardCubeState, allCubeStates, queue);

		var turnRightBackFaces = DeepCopyFaces();
		turnRightBackFaces[0, 0, 1] = Faces[5, 0, 1];
		turnRightBackFaces[0, 1, 1] = Faces[5, 1, 1];
		turnRightBackFaces[4, 0, 1] = Faces[0, 0, 1];
		turnRightBackFaces[4, 1, 1] = Faces[0, 1, 1];
		turnRightBackFaces[2, 0, 1] = Faces[4, 0, 1];
		turnRightBackFaces[2, 1, 1] = Faces[4, 1, 1];
		turnRightBackFaces[5, 0, 1] = Faces[2, 0, 1];
		turnRightBackFaces[5, 1, 1] = Faces[2, 1, 1];
		turnRightBackFaces[1, 0, 0] = Faces[1, 1, 0];
		turnRightBackFaces[1, 0, 1] = Faces[1, 0, 0];
		turnRightBackFaces[1, 1, 0] = Faces[1, 1, 1];
		turnRightBackFaces[1, 1, 1] = Faces[1, 0, 1];
		ProcessFaces(turnRightBackFaces, ref TurnRightBackCubeState, allCubeStates, queue);

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
		ProcessFaces(turnBackLeftFaces, ref TurnBackLeftCubeState, allCubeStates, queue);

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
		ProcessFaces(turnBackRightFaces, ref TurnBackRightCubeState, allCubeStates, queue);
	}

	private void ProcessFaces(
		FaceColour[,,] faces,
		ref CubeState? newCubeStateRef,
		IList<CubeState> allCubeStates,
		Queue<CubeState> queue,
		string inverseCubeStatePropertyName)
	{
		if (!DoesCubeStateExist(faces, allCubeStates))
		{
			newCubeStateRef = CreateNewCubeState(faces, allCubeStates);
			newCubeStateRef.GetType().GetProperty(inverseCubeStatePropertyName)
			queue.Enqueue(newCubeStateRef);
		}
	}

	private bool DoesCubeStateExist(FaceColour[,,] inputFaces, IList<CubeState> allCubeStates)
	{
		foreach (var cubeState in allCubeStates)
		{
			if (AreFacesEqual(inputFaces, cubeState.Faces)) {
				return true;
			}
		}
		return false;
	}

	private static bool AreFacesEqual(FaceColour[,,] inputFaces, FaceColour[,,] testFaces)
	{
		var inputFacesEnumerator = inputFaces.GetEnumerator();
		var testFacesEnumerator = testFaces.GetEnumerator();	
		while (inputFacesEnumerator.MoveNext())
		{
			testFacesEnumerator.MoveNext();
			if ((FaceColour) inputFacesEnumerator.Current != (FaceColour) testFacesEnumerator.Current)
			{
				return false;
			}
		}
		return true;
	}

	private CubeState CreateNewCubeState(FaceColour[,,] faces, IList<CubeState> allCubeStates)
	{
		var cubeState = new CubeState(faces);
		allCubeStates.Add(cubeState);
		return cubeState;
	}
}
