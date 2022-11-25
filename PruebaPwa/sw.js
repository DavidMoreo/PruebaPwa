
const CACHE = "Cache_1";


self.addEventListener('fetch', e => {

    e.respondWith(caches.match(e.request))
        .then(res => {
            if (res) return res;    
            return fetch(e.request).then(newResp => {

                caches.open(CACHE)
                    .then(cache => {
                        cache.put(e.request, newResp);
                    });
                return newResp.clone();
            });
        });
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

