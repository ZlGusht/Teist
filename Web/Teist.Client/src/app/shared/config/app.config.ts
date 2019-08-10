export const Configuration = {

    restApi: {
        prefix: `http://localhost:57698/api`,
        authentication: {
            login: '/Account/Login',
            register: '/Account/Register'
        },
        album: '/Album',
        artist: '/Artist',
        chart: '/Chart',
        piece: '/Piece',
        review: '/Review'
    },

    tokenName: 'IDENTITY_TOKEN'
};



