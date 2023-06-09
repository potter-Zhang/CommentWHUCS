const path = require('path');
const CracoLessPlugin = require("craco-less");

module.exports = {
  webpack: {
    alias: {
      src: path.resolve(__dirname, 'src'),
      srcComponent: path.resolve(__dirname, 'src/component'),
      srcCss: path.resolve(__dirname, 'src/css'),
      srcImg: path.resolve(__dirname, 'src/img'),
      srcPages: path.resolve(__dirname, 'src/pages'),
      srcRoutes: path.resolve(__dirname, 'src/routes')
    }
  },
  plugins: [{ plugin: CracoLessPlugin }],
};
