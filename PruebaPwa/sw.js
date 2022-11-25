
const CACHE = "Cache_1";


self.addEventListener("fetch", function (event) {
    event.respondWith(
        caches.match(event.request).then(function (response) {
            return response || fetch(event.request);
        })
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

