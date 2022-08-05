var y =new Audio();
const setTheme = theme =>{
    document.documentElement.className = theme;
    if(theme ==='fourth'){
        y.src = "murica.mp3";
        y.play(); 
    }
    else if(theme === 'hokie'){
        y.src ="hokie_theme.mp3";
        y.play();
    } else if(theme ==='spirit'){
        
    }
    else{
        y.pause();
        y.currentTime=0;
    }
};

function findTrail(a,b,c){
    console.log('HI');
    let elem = document.getElementById('post-code');
    let zipInput= elem.value;
    if(zipInput){
        fetch('http://api.zippopotam.us/us/'+zipInput).then((response)=>response.json()).then((resBody)=>{
            places = resBody['places'][0];
            document.querySelector('#result-zipcode').innerText = resBody['post code']; 
            document.querySelector('#result-city').innerText = places['place name'];
            document.querySelector('#result-state').innerText=places['state abbreviation'];
            document.querySelector('#result-num').innerText = a;
            document.querySelector('#result-name').innerText = b; 
            document.querySelector('result-user').innerText=c;
        })
    }
}
function mute(){
    y.pause();
    y.currentTime=0;
}
