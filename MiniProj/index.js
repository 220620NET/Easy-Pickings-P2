const setTheme = theme => document.documentElement.className = theme;
function findTrail(a,b){
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
            document.querySelector('#result-name').innerText=b;
        })
    }
}
