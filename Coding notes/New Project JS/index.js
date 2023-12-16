const timedisplay = document.querySelector("#timeDisplay");
const StartButton = document.querySelector("#StartButton");
const PauseButton = document.querySelector("#PauseButton");
const ResetButton = document.querySelector("#ResetButton");

let startTime =0;
let elapsedTime =0;
let currentTime =0;
let paused = true;
let intervalId;
let hrs=0;
let min=0;
let sec=0;

StartButton.addEventListener("click",()=>{
    if(paused){
        paused = false;
        startTime=Date.now()-elapsedTime;
        intervalId = setInterval(UpdateTime,100);
    }
});
PauseButton.addEventListener("click",()=>{
    if(!paused){
        paused =true;
        elapsedTime = Date.now()-startTime;
        clearInterval(intervalId);
    }
});
ResetButton.addEventListener("click",()=>{
    paused = true;
    clearInterval(intervalId);
    startTime=0;
    elapsedTime =0;
    hrs=0;
    min=0;
    sec=0;
    timedisplay.textContent="00:00:00";

});
function UpdateTime(){
    elapsedTime =Date.now()-startTime;
    sec = Math.floor((elapsedTime/1000)%60);
    min = Math.floor((elevatedTime/1000*60)%60);
    hrs = Math.floor((elevatedTime/1000*60*60)%60)
    
    sec=pad(sec);
    min =pad(min);
    hrs =pad(hrs);
    timedisplay.textContent =hrs+":"+min+":"+sec;
    function pad(unit){
        return(("0")+unit).length > 2? unit:"0"+unit;
    }
}
