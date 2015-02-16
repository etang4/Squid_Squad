var distanceAway = transform.position;
var mainObjectPos : Transform;
 
function Update()
{
   transform.position = mainObjectPos.position + distanceAway;
}