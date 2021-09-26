import { join } from "path";

export const devServer = {
  static: {
    directory: join(__dirname, "public"),
  },
  compress: true,
  port: 5001,
  https: false,
};
