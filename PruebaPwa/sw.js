
const CACHE = "Cache_1";


self.addEventListener('fetch', e => {
    const r = fetch(e.request).then(newResp => {
        console.log(newResp);
        cache.put(e.request, newResp);

    }).catch(r => {
        return e.respondWith(caches.match(e.request));
        console.log("offline");
    }
    );





});

self.addEventListener('install', e => {

    caches.open(CACHE)
        .then(cache => {
            console.log("Instalado");
            cache.addAll([
                '/',
                '/Home/Cart',
                '/Home/Loading',
                '/Home/NewProduct',
                '/Home/Product',
                '/Controllers/Alert.js',
                '/Content/bootstrap.css'


            ]);
        });


});

self.addEventListener('activate', e => {


});

