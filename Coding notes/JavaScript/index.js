
    const eyes = document.querySelectorAll('.eye');
    const bill = document.getElementById('bill');
    const rekt = bill.getBoundingClientRect();
    const billx = rekt.left +rekt.width /2 ;
    const billy = rekt.top + rekt.height / 2;


document.addEventListener('mousemove',(e) =>{

    const mousex = e.cl
    ientX;
    const mousey = e.clientY;


    const angleDeg = angle(mousex,mousey,billx,billy);


    eyes.forEach(eye => {
        eye.style.transform = `rotate(${90 + angleDeg}deg)`;
        bill.style.filter =`hue=rotate(${angleDeg}deg)`
    })
})

function angle(cx,cy,ex,ey){
    const dy = ey - cy;
    const dx = ex - cx;

    const rad = Math.atan2(dy,dx);
    const deg = rad*180 / Math.PI;
    return deg;
}