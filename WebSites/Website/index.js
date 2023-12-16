function CallThisFuction()
{
document.getElementById("Audio").play();
if(document.getElementById("Text").value == ""){document.getElementById("data").innerHTML = "Type SomeThing"}
else{
document.getElementById("data").innerHTML= document.getElementById("Text").value;
}
}
// const blob = document.getElementById("blob");
// document.body.onpointermove = event =>
// {
//     const {clientX,clientY} = event;
//     // blob.style.left =`${clientX}px`;
//     // blob.style.top =`${clientY}px`;
//     blob.animate({
//         left:`${clientX}px`,
//         top:`${clientY}px`
//     },{duration:2500,fill:"forwards"}
//     )
// }

