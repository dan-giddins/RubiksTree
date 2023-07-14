using System.Linq;

namespace RubiksTree;
internal class CubeState
{
	// front, right, back, left, top, bottom
	internal FaceColour[,,] Faces;
	internal CubeState? TurnBottomLeft;
	internal CubeState? TurnBottomRight;
	internal CubeState? TurnRightForward;
	internal CubeState? TurnRightBack;
	internal CubeState? TurnBackLeft;
	internal CubeState? TurnBackRight;

	public CubeState(FaceColour[,,] faces) =>
		Faces = faces;

	public FaceColour[,,] DeepCopyFaces()
	{
		var result = new FaceColour[Faces.GetLength(0), Faces.GetLength(1), Faces.GetLength(2)];
		Array.Copy(Faces, result, Faces.Length);
		return result;
	}
}
