import axios from 'axios';
import { useQuery } from 'react-query';

const claimsKeys = {
    claim: ['claims']
}

const config = {
    headers: {
        'X-CSRF': '1'
    }
}

const fetchClaims = async () =>
    axios.get('/bff/user', config)
        .then((res) => res.data);


function useClaims(enable: boolean) {
    return useQuery(
        claimsKeys.claim,
        async () => fetchClaims(),
        {
            staleTime: Infinity,
            cacheTime: Infinity,
            retry: false,
            enabled: enable,
        }
    )
}

export { useClaims as default }