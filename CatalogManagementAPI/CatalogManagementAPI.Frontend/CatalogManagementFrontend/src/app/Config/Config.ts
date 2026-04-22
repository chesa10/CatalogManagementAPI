const routes = {
    home: {
        path: 'home',
    },
    productsList: {
        path: 'products-List',
    },
    notFound: {
        path: 'not-found',
    },
    internalServerError: {
        path: 'internal-server-error',
    }
}


export const config = {
    routes,
    endpoints: {
        GET_ALL_PRODUCTS:'api/products',
        DELETE_PRODUCT: 'api/products',
        ADD_PRODUCT: 'api/products',
        PRODUCT_API: 'api/products',
        GET_ALL_Categories:'api/categories',
    }
}
