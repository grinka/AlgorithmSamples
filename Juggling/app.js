/*

abc
c -> a

cbc

*/
var gcd = (a, b) => {
    if (!b) {
        return a;
    }
    return gcd(b, a % b);
};
var setCharAt = (s, idx, char) => {
    if (idx > s.length - 1) {
        return s + char;
    }
    else {
        return s.substring(0, idx) + char + s.substring(idx + 1);
    }
};
function juggle(data, dist) {
    const n = data.length;
    let ret = data;
    let maxN = gcd(n, dist);
    console.log(maxN);
    for (let idx = 0; idx < maxN; idx++) {
        const temp = ret[idx];
        let j = idx;
        let k = -1;
        do {
            k = j + dist;
            if (k >= n) {
                k -= n;
            }
            if (k !== idx) {
                ret = setCharAt(ret, j, ret[k]);
                console.log("Moved %s", ret);
                j = k;
            }
        } while (k !== idx);
        ret = setCharAt(ret, j, temp);
    }
    return ret;
}
function main() {
    console.log("abcdef");
    console.log(juggle("abcdef", 2));
    //console.log(gcd(8, 3));
    //console.log(gcd(8, 4));
    //console.log(gcd(6, 9));
}
main();
//# sourceMappingURL=app.js.map