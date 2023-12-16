const d = new Date();
const Day =["Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"];
const Month=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"];
document.getElementById('Time').innerHTML = d;
document.getElementById('Year').innerHTML = "Year : " + d.getFullYear();
document.getElementById('Month').innerHTML = "Month : " +Month[d.getMonth()];
document.getElementById('Day').innerHTML = "Day : " +Day[d.getDay()];
document.getElementById('Hour').innerHTML = "Hours : " +d.getHours();
document.getElementById('Minute').innerHTML = "Minutes : " +d.getMinutes();
document.getElementById('Second').innerHTML = "Seconds : " +d.getSeconds();

